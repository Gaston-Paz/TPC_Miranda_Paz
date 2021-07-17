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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) { 
                List<Especialidad> aux = new List<Especialidad>();
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
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
                else
                {
                    
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
                    if (item.Dni == dni.Value)
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
                especialidad = DropEspecialidades.SelectedValue;
                DropMedicos.Visible = true;
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                List<Medico> listaMedicos = new List<Medico>();
                List<Medico> listaMedicosAux = new List<Medico>();
                listaMedicos = medicoNegocio.listar();

                foreach (Medico item in listaMedicos)
                {
                    foreach (Especialidad items in item.Especialidades)
                    {
                        if (int.Parse(especialidad) == items.Id)
                        {
                            listaMedicosAux.Add(item);
                        }
                    }
                    
                }

                DropMedicos.DataSource = listaMedicosAux;
                DropMedicos.DataTextField = "Apellido";
                DropMedicos.DataValueField = "Id";
                DropMedicos.DataBind();
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
                List<string> fechas = new List<string>();


                    
                for (int i = 0; i < 30; i++)
                {

                    
                        fechas.Add(DateTime.Now.AddDays(7*i).ToShortDateString());

                    

                }

                DropFechas.DataSource = fechas;
                DropFechas.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}