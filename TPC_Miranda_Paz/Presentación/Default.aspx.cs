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
    public partial class _Default : Page
    {
        public int cantMedicos = 0;
        public int cantPacientes = 0;
        public int cantRecepcionistas = 0;
        public int cantEspecialidades = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            cantMedicos = medicoNegocio.listar().Count;
            lblcantmedicos.Text = cantMedicos.ToString();

            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            cantPacientes = pacienteNegocio.listar().Count;
            lblcantpacientes.Text = cantPacientes.ToString();

            RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
            cantRecepcionistas = recepcionistaNegocio.listar().Count;
            lblcantrecepcionistas.Text = cantRecepcionistas.ToString();

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            cantEspecialidades = especialidadNegocio.listar().Count;
            lblcantespecialidades.Text = cantEspecialidades.ToString();

        }
    }
}