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
    public partial class MisTurnos : System.Web.UI.Page
    {
        List<Turno> listaTurnos;
        List<Turno> listaTurnosAux;
        List<Turno> listaFiltrada;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaTurnos = new List<Turno>();
            listaTurnosAux = new List<Turno>();
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            listaTurnosAux = turnoNegocio.listar_turnos_ocupados();
            ///DateTime prueba = DateTime.Now.AddDays(4);
            DateTime prueba = DateTime.Now;


            try
            {

                if (((Usuario)Session["user"]).TipoUsuario != 3)
                {
                    Response.Redirect("Error.aspx");
                }

                foreach (Turno item in listaTurnosAux)
                {
                    if ((item.Medico.Email == ((Usuario)Session["user"]).Email) && (item.Fecha == prueba.Date))
                    {
                        listaTurnos.Add(item);
                    }
                }

                GridTurnosDia.DataSource = listaTurnos;
                GridTurnosDia.DataBind();

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
        }

        protected void GridTurnosDia_Load(object sender, EventArgs e)
        {
            GridTurnosDia.CssClass = "table table-bordered table-hover";
            GridTurnosDia.HeaderStyle.CssClass = "thead-dark";
        }

        protected void GridTurnosDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                List<EstadoTurno> estadoTurno = new List<EstadoTurno>();

                estadoTurno = turnoNegocio.listarEstados();
                DropEstado.DataSource = estadoTurno;
                DropEstado.DataTextField = "Nombre";
                DropEstado.DataValueField = "Id";
                DropEstado.DataBind();

                GridViewRow devuelto = GridTurnosDia.SelectedRow;

                string id = devuelto.Cells[0].Text;

                foreach (Turno item in listaTurnos)
                {
                    if (item.Id.ToString() == id)
                    {
                        TxtId.Text = item.Id.ToString();
                        TxtApellido.Text = item.Paciente.Apellido;
                        TxtNombre.Text = item.Paciente.Nombre;
                        TxtDNI.Text = item.Paciente.Dni;
                        TxtFecha.Text = item.Fecha.ToShortDateString();
                        TxTHora.Text = item.Horario + ":00";
                        DropEstado.SelectedValue = item.Estado.Id.ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                Turno turno = new Turno();

                turno.Id = int.Parse(TxtId.Text);
                turno.Estado = new EstadoTurno();
                turno.Estado.Id = int.Parse(DropEstado.SelectedValue);
                turno.Observacion = TxtObservación.Text;

                turnoNegocio.Modificar(turno.Id, turno.Estado.Id, turno.Observacion);

            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("MisTurnos.aspx");
        }

        protected void GridTodosTurnos_Load(object sender, EventArgs e)
        {
            GridTodosTurnos.CssClass = "table table-bordered table-hover";
            GridTodosTurnos.HeaderStyle.CssClass = "thead-dark";

            try
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                List<Turno> listaTurnos = new List<Turno>();
                List<Turno> listaTurnosAux = new List<Turno>();
                listaTurnos = turnoNegocio.listar_turnos_ocupados();
                List<EstadoTurno> estadoTurno = new List<EstadoTurno>();

                estadoTurno = turnoNegocio.listarEstados();


                foreach (Turno item in listaTurnos)
                {
                    if (item.Medico.Email == ((Usuario)Session["user"]).Email)
                    {
                        if (item.Estado.Id == 5)
                        {
                            listaTurnosAux.Add(item);
                        }
                    }
                }

                GridTodosTurnos.DataSource = listaTurnosAux;
                GridTodosTurnos.DataBind();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listaTurnos = new List<Turno>();
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                listaTurnos = turnoNegocio.listar_turnos_ocupados();

                if (listaFiltrada == null)
                {
                    listaFiltrada = new List<Turno>();

                    foreach (Turno item in listaTurnos)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Paciente.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            if (item.Estado.Id == 5)
                            {
                                listaFiltrada.Add(item);

                            }
                        }
                        
                    }
                }
                else
                {
                    List<Turno> listaAux = new List<Turno>();

                    foreach (Turno item in listaFiltrada)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Paciente.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            listaAux.Add(item);
                        }
                        
                    }
                    listaFiltrada.Clear();
                    listaFiltrada = listaAux;
                }

                GridTodosTurnos.DataSource = listaFiltrada;
                GridTodosTurnos.DataBind();
            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
        }
    }
}