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

                GridMedicos.DataSource = listaMedicos;
                GridMedicos.DataBind();
                //DropDownList1.DataSource = listaEspecialidades;
                //DropDownList1.DataTextField = "Nombre";
                //DropDownList1.DataValueField = "Id";
                //DropDownList1.DataBind();

                foreach (Dominio.Especialidad item in listaEspecialidades)
                {
                    ListItem aux = new ListItem(item.Nombre, item.Id.ToString());
                    ListEspecialidades.Items.Add(aux);
                    ListEspecialidades2.Items.Add(aux);
                    ListEspecialidades3.Items.Add(aux);
                    DropDownList1.Items.Add(aux);

                }

                Session.Add("Especialidades", listaEspecialidades);
                Session.Add("Medicos", listaMedicos);

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
          
        }

        protected void BtnEditarMedico_Click(object sender, EventArgs e)
        {
            TxtNombre.ReadOnly = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
  
            if(ListEspecialidades.SelectedValue != "-1" && ListEspecialidades2.Visible == false)
            {
                ListEspecialidades2.Visible = true;
            }
            else
            {
                if(ListEspecialidades2.SelectedValue != "-1" && ListEspecialidades3.Visible == false)
                {
                    ListEspecialidades3.Visible = true;
                }
            }
            
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = int.Parse(DropDownList1.SelectedItem.Value);
            List<Medico> listaFiltrada = new List<Medico>();
            foreach (Medico item in listaMedicos)
            {
                foreach (Especialidad items in item.Especialidades)
                {
                    if(items.Id == valor)
                    {
                        listaFiltrada.Add(item);
                    }
                }
            }
            GridMedicos.DataSource = listaFiltrada;
            GridMedicos.DataBind();
        }


    }
}