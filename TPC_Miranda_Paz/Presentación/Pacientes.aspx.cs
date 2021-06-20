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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                listaPacientes = pacienteNegocio.listar();

                Session.Add("Pacientes", listaPacientes);

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
        }
    }
}