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
        public List<Especialidad> listaEspecialidades;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                listaMedicos = medicoNegocio.listar();
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                listaEspecialidades = especialidadNegocio.listar();

                foreach (Dominio.Especialidad item in listaEspecialidades)
                {
                    ListItem aux = new ListItem(item.Nombre, item.Id.ToString());
                    ListEspecialidades.Items.Add(aux);

                }

                Session.Add("Especialidades", listaEspecialidades);
                Session.Add("Medicos", listaMedicos);

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
          
        }
    }
}