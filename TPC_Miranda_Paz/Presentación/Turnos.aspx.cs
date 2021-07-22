using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentación
{
    public partial class Turnos : System.Web.UI.Page
    {
        List<Paciente> listapacientes;
        List<Especialidad> listaEspecialidades;
        public string especialidad;
        List<Turno> listaTurnos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Dominio.Usuario)Session["user"]).TipoUsuario == 3)
            {
                Response.Redirect("Error.aspx");
            }

            try
            {
                if (!IsPostBack) {
                    
                    List<Especialidad> aux = new List<Especialidad>();
                    EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    listaTurnos = new List<Turno>();

                    listaTurnos = turnoNegocio.listar_turnos_ocupados();

                    listaTurnos = listaTurnos.OrderBy(x => x.Horario).OrderBy(i => i.Fecha).ToList();

                    foreach (Turno item in listaTurnos)
                    {
                        item.Fechas = item.Fecha.ToShortDateString();
                    }
                    
                    GridTurnos.DataSource = listaTurnos;
                    GridTurnos.DataBind();

                    aux = especialidadNegocio.listar();
                    listaEspecialidades = new List<Especialidad>();
                    listaEspecialidades.Add(new Especialidad("*Seleccionar", 0));
                    foreach (Especialidad item in aux)
                    {
                        listaEspecialidades.Add(item);
                    }
                    DropEspecialidades.DataSource = listaEspecialidades;
                    DropEspecialidades.DataTextField = "Nombre";
                    DropEspecialidades.DataValueField = "Id";
                    DropEspecialidades.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                listapacientes = new List<Paciente>();
                listapacientes = (List<Paciente>)Session["Pacientes"];

                foreach (Paciente item in listapacientes)
                {
                    if (item.Dni == dni.Value.Trim())
                    {
                        nombre.Value = item.Nombre;
                        apellido.Value = item.Apellido;
                        nombre.Visible = true;
                        apellido.Visible = true;
                        DropEspecialidades.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void DropEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                                
                ///CARGO PROFESIONALES AL DROP
                especialidad = DropEspecialidades.SelectedValue;
                DropMedicos.Visible = true;
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                List<Medico> listaMedicos = new List<Medico>();
                List<Medico> listaMedicosAux = new List<Medico>();
                listaMedicos = medicoNegocio.listar();
                bool bandera = true;

                foreach (Medico item in listaMedicos)
                {
                    foreach (Especialidad items in item.Especialidades)
                    {
                        if (int.Parse(especialidad) == items.Id)
                        {
                            if (bandera)
                            {
                                bandera = false;
                                listaMedicosAux.Add(new Medico(0, "*Seleccionar", "", ""));
                            }
                            listaMedicosAux.Add(item);
                        }
                    }
                    
                }

                DropMedicos.DataSource = listaMedicosAux;
                DropMedicos.DataTextField = "Apellido";
                DropMedicos.DataValueField = "Id";
                DropMedicos.DataBind();

                ///CARGO GRILLA DE OFERTA
                DisponibilidadMedicoNegocio disponibilidadMedicoNegocio = new DisponibilidadMedicoNegocio();
                List<DateTime> Mes = new List<DateTime>();
                List<DisponibilidadMedico> disponibilidadMedico = new List<DisponibilidadMedico>();
                
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                
                List<Turno> turnos = new List<Turno>();

                for (int i = 0; i < 30; i++)
                {
                    Mes.Add(DateTime.Now.AddDays(i));
                }

                foreach (DateTime mes in Mes)
                {
                    foreach (Medico medico in listaMedicos)
                    {
                        foreach (Especialidad especialidad in medico.Especialidades)
                        {
                            if(especialidad.Id == int.Parse(DropEspecialidades.SelectedValue))
                            {
                                disponibilidadMedico = disponibilidadMedicoNegocio.listar(medico.Id);

                                foreach (DisponibilidadMedico disponibilidad in disponibilidadMedico)
                                {
                                    List<int> horarios = new List<int>();
                                    List<int> borrar = new List<int>();
                                    if ((DayOfWeek)disponibilidad.Dia.Id == mes.Date.DayOfWeek)
                                    {
                                        for (int x = disponibilidad.Entrada; x <= disponibilidad.Salida; x++)
                                        {
                                            horarios.Add(x);
                                        }

                                        if (horarios.Count > 0)
                                        {
                                            foreach (Turno turn in turnoNegocio.turnos_ocupado_especialidad_fecha(especialidad.Id,medico.Id,mes.Date))
                                            {
                                                foreach (int hora in horarios)
                                                {
                                                    if (turn.Horario == hora)
                                                    {
                                                        if(turn.Estado.Id != 2 && turn.Estado.Id != 3)
                                                        {
                                                            borrar.Add(hora);

                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        foreach (int hs in borrar)
                                        {
                                            horarios.Remove(hs);
                                        }

                                        foreach (int horas in horarios)
                                        {
                                            Turno turno = new Turno();
                                            turno.Medico = new Medico();
                                            turno.Especialidad = new Especialidad();
                                            turno.Medico = medico;
                                            turno.Especialidad = especialidad;
                                            turno.Fecha = mes;
                                            turno.Horario = horas;
                                            turnos.Add(turno);
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                turnos = turnos.OrderBy(i => i.Horario).OrderBy(x => x.Fecha).ToList();
                GridTurnosPredictivo.DataSource = turnos;
                GridTurnosPredictivo.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void DropMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropFechas.Visible = true;
                List<DateTime> fechas = new List<DateTime>();
                DisponibilidadMedicoNegocio disponibilidadMedicoNegocio = new DisponibilidadMedicoNegocio();
                List<DisponibilidadMedico> diasDisponibles = disponibilidadMedicoNegocio.listar(int.Parse(DropMedicos.SelectedValue));
                
                int diferencia = 0;

                DayOfWeek hoy = new DayOfWeek();
                hoy = DateTime.Now.DayOfWeek;

                DayOfWeek diaSeleccionado = new DayOfWeek();

                DateTime fechaaux = new DateTime();
                fechaaux = DateTime.Now;

                diasDisponibles = diasDisponibles.OrderBy(x => x.Dia.Id).ToList();

                foreach (DisponibilidadMedico item in diasDisponibles)
                {
                    diaSeleccionado = (DayOfWeek)item.Dia.Id;
                    switch (diaSeleccionado)
                    {
                        case DayOfWeek.Monday:
                            if(hoy == diaSeleccionado) { 
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                }
                            }
                            else {
                                diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                fechaaux = fechaaux.AddDays(diferencia);
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(fechaaux.AddDays(7 * i).Date);
                                }
                            }
                            break;
                        case DayOfWeek.Tuesday:
                            if (hoy == diaSeleccionado)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                }
                            }
                            else
                            {
                                diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                fechaaux = fechaaux.AddDays(diferencia);
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(fechaaux.AddDays(7 * i).Date);
                                }
                            }
                            break;
                        case DayOfWeek.Wednesday:
                            if (hoy == diaSeleccionado)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                }
                            }
                            else
                            {
                                diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                fechaaux = fechaaux.AddDays(diferencia);
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(fechaaux.AddDays(7 * i).Date);
                                }
                            }
                            break;
                        case DayOfWeek.Thursday:
                            if (hoy == diaSeleccionado)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                }
                            }
                            else
                            {
                                diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                fechaaux = fechaaux.AddDays(diferencia);
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(fechaaux.AddDays(7 * i).Date);
                                }
                            }
                            break;
                        case DayOfWeek.Friday:
                            if (hoy == diaSeleccionado)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                }
                            }
                            else
                            {
                                diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                fechaaux = fechaaux.AddDays(diferencia);
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(fechaaux.AddDays(7 * i).Date);
                                }
                            }
                            break;
                        case DayOfWeek.Saturday:
                            if (hoy == diaSeleccionado)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                }
                            }
                            else
                            {
                                diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                fechaaux = fechaaux.AddDays(diferencia);
                                for (int i = 0; i < 4; i++)
                                {
                                    fechas.Add(fechaaux.AddDays(7 * i).Date);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                   
                }
                    

                 ///ORDENAR LA LISTA DE FECHAS
                fechas = fechas.OrderBy(x => x.Date).ToList();

                bool bandera = true;

                foreach (DateTime item in fechas)
                {
                    if (bandera)
                    {
                        DropFechas.Items.Add("*Seleccionar");
                        bandera = false;
                    }

                    DropFechas.Items.Add(item.ToShortDateString());
                    
                }

                DropFechas.DataBind();
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void DropFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropHorarios.Visible = true;

                DateTime prueba = DateTime.Parse(DropFechas.SelectedValue);
                DisponibilidadMedicoNegocio disponibilidadMedicoNegocio = new DisponibilidadMedicoNegocio();
                List<DisponibilidadMedico> disponibilidadMedicos = new List<DisponibilidadMedico>();

                disponibilidadMedicos = disponibilidadMedicoNegocio.listar(int.Parse(DropMedicos.SelectedValue));

                List<string> horas = new List<string>();
                horas.Add("*Seleccionar");

                string seleccionado = DropFechas.SelectedItem.Value;
                DayOfWeek seleccion = DateTime.Parse(seleccionado).DayOfWeek;

                foreach (DisponibilidadMedico item in disponibilidadMedicos)
                {
                    if ((DayOfWeek)item.Dia.Id == seleccion)
                    {
                        for (int i = item.Entrada; i <= item.Salida; i++)
                        {
                            horas.Add(i.ToString());
                        }
                    }
                }


                ///QUITAR DE LA LISTA LOS HORARIOS OCUPADOS
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                List<Turno> listaTurnosOcupados = new List<Turno>();
                listaTurnosOcupados = turnoNegocio.listar_turnos_ocupados();

                foreach (Turno items in listaTurnosOcupados)
                {
                    if (items.Medico.Id == int.Parse(DropMedicos.SelectedValue) &&
                        items.Especialidad.Id == int.Parse(DropEspecialidades.SelectedValue) &&
                        items.Fecha == DateTime.Parse(DropFechas.SelectedValue))
                    {
                        if(items.Estado.Id != 2 && items.Estado.Id != 3)
                        {
                            horas.Remove(items.Horario.ToString());
                        }
                    }
                }

                DropHorarios.DataSource = horas;
                DropHorarios.DataBind();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void BtnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                EmailService emailService = new EmailService();

                ///AGREGO UN TURNO
                Turno turno = new Turno();
                TurnoNegocio turnoNegocio = new TurnoNegocio();

                List<Paciente> pacientes = new List<Paciente>();
                pacientes = (List<Paciente>)Session["Pacientes"];

                List<Medico> medicos = new List<Medico>();
                medicos = (List<Medico>)Session["Medicos"];


                turno.Medico = new Medico();
                
                foreach (Medico items in medicos)
                {
                    if (items.Id == int.Parse(DropMedicos.SelectedValue))
                    {
                        turno.Medico.Id = items.Id;
                        turno.Medico.Nombre = items.Nombre;
                        turno.Medico.Apellido = items.Apellido;
                    }
                }

                foreach (Paciente item in pacientes)
                {
                    if(item.Dni == dni.Value)
                    {
                        turno.Paciente = new Paciente();
                        turno.Paciente.Id = item.Id;
                        turno.Paciente.Apellido = item.Apellido;
                        turno.Paciente.Nombre = item.Nombre;
                        turno.Paciente.Email = item.Email;
                    }
                }
                turno.Estado = new EstadoTurno();
                turno.Estado.Id = 1;
                turno.Especialidad = new Especialidad();
                turno.Especialidad.Id = int.Parse(DropEspecialidades.SelectedValue);
                turno.Especialidad.Nombre = DropEspecialidades.SelectedItem.ToString();
                turno.Horario = int.Parse(DropHorarios.SelectedValue);
                turno.Fecha = DateTime.Parse(DropFechas.SelectedValue);

                turnoNegocio.agregar(turno);
                int cantidadTurnos = turnoNegocio.listar_turnos_ocupados().Count;
                emailService.armarCorreo(turno, cantidadTurnos);
                emailService.enviarEmail();
                                
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                Response.Redirect("Turnos.aspx");
            }
        }

        protected void GridTurnosPredictivo_Load(object sender, EventArgs e)
        {
            GridTurnosPredictivo.CssClass = "table table-bordered table-hover";
            GridTurnosPredictivo.HeaderStyle.CssClass = "thead-dark";
        }

        protected void GridTurnosPredictivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow devuelto = GridTurnosPredictivo.SelectedRow;

                string id = devuelto.Cells[0].Text;
                string fecha = devuelto.Cells[3].Text;
                string hora = devuelto.Cells[4].Text;
                

                DropMedicos.Visible = true;
                List<Medico> listaMedicos = new List<Medico>();
                listaMedicos = (List<Medico>)Session["Medicos"];
                foreach (Medico item in listaMedicos)
                {
                    if (id == item.Id.ToString())
                    {
                        ///CARGO EL DROP DE FECHAS Y SELECCIONO LA QUE NECESITO
                        DropFechas.Visible = true;
                        List<DateTime> fechas = new List<DateTime>();
                        DisponibilidadMedicoNegocio disponibilidadMedicoNegocio = new DisponibilidadMedicoNegocio();
                        List<DisponibilidadMedico> diasDisponibles = disponibilidadMedicoNegocio.listar(int.Parse(id));

                        int diferencia = 0;

                        DayOfWeek hoy = new DayOfWeek();
                        hoy = DateTime.Now.DayOfWeek;

                        DayOfWeek diaSeleccionado = new DayOfWeek();

                        DateTime fechaaux = new DateTime();
                        fechaaux = DateTime.Now;

                        diasDisponibles = diasDisponibles.OrderBy(x => x.Dia.Id).ToList();

                        foreach (DisponibilidadMedico itemse in diasDisponibles)
                        {
                            diaSeleccionado = (DayOfWeek)itemse.Dia.Id;
                            switch (diaSeleccionado)
                            {
                                case DayOfWeek.Monday:
                                    if (hoy == diaSeleccionado)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                        }
                                    }
                                    else
                                    {
                                        diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                        fechaaux = fechaaux.AddDays(diferencia);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(fechaaux.AddDays(7 * i).Date);
                                        }
                                    }
                                    break;
                                case DayOfWeek.Tuesday:
                                    if (hoy == diaSeleccionado)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                        }
                                    }
                                    else
                                    {
                                        diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                        fechaaux = fechaaux.AddDays(diferencia);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(fechaaux.AddDays(7 * i).Date);
                                        }
                                    }
                                    break;
                                case DayOfWeek.Wednesday:
                                    if (hoy == diaSeleccionado)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                        }
                                    }
                                    else
                                    {
                                        diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                        fechaaux = fechaaux.AddDays(diferencia);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(fechaaux.AddDays(7 * i).Date);
                                        }
                                    }
                                    break;
                                case DayOfWeek.Thursday:
                                    if (hoy == diaSeleccionado)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                        }
                                    }
                                    else
                                    {
                                        diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                        fechaaux = fechaaux.AddDays(diferencia);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(fechaaux.AddDays(7 * i).Date);
                                        }
                                    }
                                    break;
                                case DayOfWeek.Friday:
                                    if (hoy == diaSeleccionado)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                        }
                                    }
                                    else
                                    {
                                        diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                        fechaaux = fechaaux.AddDays(diferencia);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(fechaaux.AddDays(7 * i).Date);
                                        }
                                    }
                                    break;
                                case DayOfWeek.Saturday:
                                    if (hoy == diaSeleccionado)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(DateTime.Now.AddDays(7 * i).Date);
                                        }
                                    }
                                    else
                                    {
                                        diferencia = ((int)diaSeleccionado) - ((int)hoy);
                                        fechaaux = fechaaux.AddDays(diferencia);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            fechas.Add(fechaaux.AddDays(7 * i).Date);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }


                        ///ORDENAR LA LISTA DE FECHAS
                        fechas = fechas.OrderBy(x => x.Date).ToList();

                        bool bandera = true;

                        foreach (DateTime itemsa in fechas)
                        {
                            if (bandera)
                            {
                                DropFechas.Items.Add("*Seleccionar");
                                bandera = false;
                            }

                            DropFechas.Items.Add(itemsa.ToShortDateString());

                        }

                        DropFechas.DataBind();

                        ///CARGO LOS HORARIOS Y SELECCIONO EL QUE NECESITO
                        DateTime prueba = DateTime.Parse(fecha);
                        
                        List<string> horas = new List<string>();
                        horas.Add("*Seleccionar");

                        string seleccionado = fecha;
                        DayOfWeek seleccion = DateTime.Parse(seleccionado).DayOfWeek;

                        foreach (DisponibilidadMedico itemsw in diasDisponibles)
                        {
                            if ((DayOfWeek)itemsw.Dia.Id == seleccion)
                            {
                                for (int i = itemsw.Entrada; i <= itemsw.Salida; i++)
                                {
                                    horas.Add(i.ToString());
                                }
                            }
                        }


                        ///QUITAR DE LA LISTA LOS HORARIOS OCUPADOS
                        TurnoNegocio turnoNegocio = new TurnoNegocio();
                        List<Turno> listaTurnosOcupados = new List<Turno>();
                        listaTurnosOcupados = turnoNegocio.listar_turnos_ocupados();

                        foreach (Turno items in listaTurnosOcupados)
                        {
                            if (items.Medico.Id == int.Parse(id) &&
                                items.Especialidad.Id == int.Parse(DropEspecialidades.SelectedValue) &&
                                items.Fecha == DateTime.Parse(fecha))
                            {
                                horas.Remove(items.Horario.ToString());
                            }
                        }

                        DropHorarios.DataSource = horas;
                        DropHorarios.DataBind();

                        ///MUESTRO TODOS LOS DROPS SETEADOS
                        DropMedicos.Visible = true;
                        DropMedicos.SelectedValue = id;
                        DropFechas.Visible = true;
                        DropFechas.SelectedValue = DateTime.Parse(fecha).ToShortDateString();
                        DropHorarios.Visible = true;
                        DropHorarios.SelectedValue = hora;
                    }
                }

                

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void GridTurnos_Load(object sender, EventArgs e)
        {
            GridTurnos.CssClass = "table table-bordered table-hover";
            GridTurnos.HeaderStyle.CssClass = "thead-dark";
            
        }

        protected void GridTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow devuelto = GridTurnos.SelectedRow;

                string id = devuelto.Cells[0].Text;

                LblTurno.Text = LblTurno.Text + id;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow devuelto = GridTurnos.SelectedRow;

                int id = int.Parse(devuelto.Cells[0].Text);

                int estadoSeleccionado = int.Parse(DropEstados.SelectedValue);
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                turnoNegocio.modificar(id, estadoSeleccionado);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}