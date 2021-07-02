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
        public Paciente error;

        protected void Page_Load(object sender, EventArgs e)
        {
            error = new Paciente();
            if(Session["Paciente"] != null)
                error = (Paciente)Session["Paciente"];
               
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                listaPacientes = pacienteNegocio.listar();

                Session.Add("Pacientes", listaPacientes);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        protected void Registar_Click(object sender, EventArgs e)
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
                
                if(pacienteNegocio.chequear_dni(nuevo.Dni) > 0)
                {
                    /// DNI REPETIDO
                    //dni.Attributes["class"] = "is-invalid";
                    dni.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }
                if(pacienteNegocio.chequear_email(nuevo.Email) > 0)
                {
                    email.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }
                    
                if(agregar == true)
                {
                 pacienteNegocio.agregar(nuevo);
                 Session.Remove("Paciente");

                }


            }
            catch (Exception ex)
            {

                throw;
            }

            //Response.Redirect("Pacientes.aspx");
        }
    }
}