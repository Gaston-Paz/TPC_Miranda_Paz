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
    public partial class Pacientes : System.Web.UI.Page
    {
        public List<Paciente> listaPacientes;
        public List<Paciente> listaBusqueda;
        public string prueba;
        protected void Page_Load(object sender, EventArgs e)
        {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                listaPacientes = pacienteNegocio.listar();
            try
            {

                if (!IsPostBack)
                {
                    ///CARGO LA GRILLA
                    GridPacientes.DataSource = listaPacientes;
                    GridPacientes.DataBind();

                    Session.Add("Pacientes", listaPacientes);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void GridPacientes_Load(object sender, EventArgs e)
        {
            GridPacientes.CssClass = "table table-bordered table-hover";
            GridPacientes.HeaderStyle.CssClass = "thead-dark";
        }


        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            bool agregar = true;
            Paciente nuevo = new Paciente();
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            try
            {
                nuevo.Nombre = nombre.Value;
                nuevo.Apellido = apellido.Value;
                nuevo.Dni = dni.Value;
                nuevo.Email = email.Value;
                nuevo.FechaNacimiento = DateTime.Parse(fechaNacimiento.Value);
                nuevo.Telefono = telefono.Value;
                nuevo.Estado = true;

                Session.Add("Paciente", nuevo);

                if (pacienteNegocio.chequear_dni(nuevo.Dni) > 0)
                {
                    /// DNI REPETIDO
                    dni.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }

                if (pacienteNegocio.chequear_email(nuevo.Email) > 0)
                {
                    email.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }




            }
            catch (Exception ex)
            {

                throw;
            }
            if (agregar == true)
            {
                pacienteNegocio.agregar(nuevo);
                Session.Remove("Paciente");
                Response.Redirect("Pacientes.aspx");

            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente nuevo = new Paciente();
                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                nuevo.Nombre = TxtNombre.Text;
                nuevo.Apellido = TxtApellido.Text;
                nuevo.Dni = TxtDNI.Text;
                nuevo.Telefono = TxtTelefono.Text;
                nuevo.Email = TxtEmail.Text;
                nuevo.FechaNacimiento = DateTime.Parse(fechaNac.Value);
                nuevo.Estado = true;
                nuevo.Id = int.Parse(TxtId.Text);

                pacienteNegocio.modificar(nuevo);

                listaPacientes = pacienteNegocio.listar();
                Session.Remove("Pacientes");
                Session.Add("Pacientes", listaPacientes);


            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Pacientes.aspx");

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                pacienteNegocio.eliminar(int.Parse(TxtId.Text));

                listaPacientes = pacienteNegocio.listar();
                Session.Remove("Pacientes");
                Session.Add("Pacientes", listaPacientes);


            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Pacientes.aspx");

        }

        protected void GridPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridPacientes.SelectedIndex;

            GridViewRow devuelto = GridPacientes.SelectedRow;

            string dni = devuelto.Cells[2].Text;

            foreach (Paciente item in listaPacientes)
            {
                if (dni == item.Dni)
                {
                    /// CARGO LOS TEXT DEL MODAL
                    TxtId.Text = item.Id.ToString();
                    TxtNombre.Text = item.Nombre;
                    TxtApellido.Text = item.Apellido;
                    TxtDNI.Text = item.Dni;
                    TxtEmail.Text = item.Email;
                    TxtTelefono.Text = item.Telefono;
                    fechaNac.Value = item.FechaNacimiento.ToString();
                }
            }


            

        }

        

        protected void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (listaBusqueda == null)
                {
                    listaBusqueda = new List<Paciente>();

                    foreach (Paciente item in listaBusqueda)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            listaBusqueda.Add(item);
                        }
                        else
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                listaBusqueda.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    List<Paciente> listaAux = new List<Paciente>();

                    foreach (Paciente item in listaBusqueda)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            listaAux.Add(item);
                        }
                        else
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                listaAux.Add(item);
                            }
                        }
                    }
                    listaBusqueda.Clear();
                    listaBusqueda = listaAux;
                }
                GridPacientes.DataSource = listaBusqueda;
                GridPacientes.DataBind();

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
        }
    }
}