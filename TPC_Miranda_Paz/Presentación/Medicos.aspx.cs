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
    public partial class Medicos : System.Web.UI.Page
    {
        public List<Medico> listaMedicos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                listaMedicos = medicoNegocio.listar();

                Session.Add("Medicos", listaMedicos);

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
          
        }
    }
}