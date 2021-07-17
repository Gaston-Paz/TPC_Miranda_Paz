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
    public partial class SiteMaster : MasterPage
    {

     
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                Session.Add("Pacientes", pacienteNegocio.listar());
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                Session.Add("Especialidades", especialidadNegocio.listar());
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                Session.Add("Medicos", medicoNegocio.listar());

            }
            catch (Exception ex)
            {

                
            }

        }
    }
}