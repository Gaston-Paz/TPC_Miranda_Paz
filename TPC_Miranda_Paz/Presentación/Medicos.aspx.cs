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
        public List<Medico> listaFiltrada;
        public List<Especialidad> listaEspecialidades;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                listaMedicos = medicoNegocio.listar();
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                listaEspecialidades = especialidadNegocio.listar();

                if (!IsPostBack) { 
                ///CARGO LA GRILLA
                GridMedicos.DataSource = listaMedicos;
                GridMedicos.DataBind();
                
                ///CARGO LOS DROPS DEL MODAL
                DDModalEspecialidades.DataSource = listaEspecialidades;
                DDModalEspecialidades.DataTextField = "Nombre";
                DDModalEspecialidades.DataValueField = "Id";
                DDModalEspecialidades.DataBind();

                DDModalEspecialidades2.DataSource = listaEspecialidades;
                DDModalEspecialidades2.DataTextField = "Nombre";
                DDModalEspecialidades2.DataValueField = "Id";
                DDModalEspecialidades2.DataBind();

                DDModalEspecialidades3.DataSource = listaEspecialidades;
                DDModalEspecialidades3.DataTextField = "Nombre";
                DDModalEspecialidades3.DataValueField = "Id";
                DDModalEspecialidades3.DataBind();

                ///CARGO LOS DROPS DEL FORM DE REGISTRO
                ListEspecialidades.DataSource = listaEspecialidades;
                ListEspecialidades.DataTextField = "Nombre";
                ListEspecialidades.DataValueField = "Id";
                ListEspecialidades.DataBind();

                ListEspecialidades2.DataSource = listaEspecialidades;
                ListEspecialidades2.DataTextField = "Nombre";
                ListEspecialidades2.DataValueField = "Id";
                ListEspecialidades2.DataBind();

                ListEspecialidades3.DataSource = listaEspecialidades;
                ListEspecialidades3.DataTextField = "Nombre";
                ListEspecialidades3.DataValueField = "Id";
                ListEspecialidades3.DataBind();

                ListEspecialidadesGrid.DataSource = listaEspecialidades;
                ListEspecialidadesGrid.DataTextField = "Nombre";
                ListEspecialidadesGrid.DataValueField = "Id";
                ListEspecialidadesGrid.DataBind();

                ///GUARDO EN SESION MEDICOS Y ESPECIALIDADES
                Session.Add("Especialidades", listaEspecialidades);
                Session.Add("Medicos", listaMedicos);
                }

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
          
        }

        protected void BtnEditarMedico_Click(object sender, EventArgs e)
        {
            ///SE HABILITAN LOS CAMPOS DEL MODAL PARA PODER EDITARLOS
            TxtId.ReadOnly = false;
            TxtNombre.ReadOnly = false;
            TxtApellido.ReadOnly = false;
            TxtDNI.ReadOnly = false;
            TxtEmail.ReadOnly = false;
            TxtTelefono.ReadOnly = false;
            TxtMatricula.ReadOnly = false;
            TxtPass.ReadOnly = false;

        }

        protected void BtnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            ///SE MUESTRA UN NUEVO DROP PARA SUMAR ESPECIALIDADES
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
            ///SE GUARDA UN MEDICO NUEVO

            Medico nuevo = new Medico();
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            List<Especialidad> nueva = new List<Especialidad>();

            ///ASIGNO TODAS LAS PROP
            nuevo.Nombre = nombre.Value;
            nuevo.Apellido = apellido.Value;
            nuevo.Dni = dni.Value;
            nuevo.Email = email.Value;
            nuevo.Password = password.Value;
            nuevo.Martricula = matricula.Value;
            nuevo.Especialidades = new List<Especialidad>();

            foreach (Especialidad item in listaEspecialidades)
            {
                if(item.Nombre == ListEspecialidades.SelectedItem.Text)
                {
                    nuevo.Especialidades.Add(item);
                }
                if(ListEspecialidades2.Visible == true && item.Nombre == ListEspecialidades2.SelectedItem.Text) 
                {
                    nuevo.Especialidades.Add(item);
                }
                if (ListEspecialidades3.Visible == true && item.Nombre == ListEspecialidades3.SelectedItem.Text)
                {
                    nuevo.Especialidades.Add(item);
                }



            }

            ///GUARDO EN LA DB
            medicoNegocio.agregar(nuevo);
            

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///SE FILTRA LA GRILLA DE MEDICOS DE ACUERDO AL DROP
            int valor = int.Parse(ListEspecialidadesGrid.SelectedItem.Value);
            listaFiltrada = new List<Medico>();
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

            if(listaFiltrada.Count == 0)
            {
                listaFiltrada = listaMedicos;
            }

            GridMedicos.DataSource = listaFiltrada;
            GridMedicos.DataBind();
        }

        protected void GridMedicos_Load(object sender, EventArgs e)
        {
            ///CLASES DEL GRID
            GridMedicos.CssClass = "table table-bordered table-hover";
            GridMedicos.HeaderStyle.CssClass = "thead-dark";
        }

        protected void GridMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///SE TRAE EL MEDICO SELECCIONADO PARA CARGAR EN EL MODAL
            int index = GridMedicos.SelectedIndex;

            int aux = 0;

            GridViewRow devuelto = GridMedicos.SelectedRow;

            string dni = devuelto.Cells[2].Text;

            DDModalEspecialidades2.Visible = false;
            DDModalEspecialidades3.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;

            foreach (Medico item in listaMedicos)
            {
                if (dni == item.Email)
                {
                    /// CARGO LOS TEXT DEL MODAL
                    TxtId.Text = item.Id.ToString();
                    TxtNombre.Text = item.Nombre;
                    TxtApellido.Text = item.Apellido;
                    TxtDNI.Text = item.Dni;
                    TxtEmail.Text = item.Email;
                    TxtTelefono.Text = item.Telefono;
                    TxtMatricula.Text = item.Martricula;
                    TxtPass.Text = item.Password;

                    foreach (Especialidad items in item.Especialidades)
                    {
                        if(aux == 0) { 
                        DDModalEspecialidades.SelectedValue = items.Id.ToString();
                            aux++;
                        }
                        else
                        {
                            if(aux == 1)
                            {
                                DDModalEspecialidades2.SelectedValue = items.Id.ToString();
                                aux++;
                                DDModalEspecialidades2.Visible = true;
                                Label1.Visible = true;
                            }
                            else
                            {
                                if (aux == 1)
                                {
                                    DDModalEspecialidades3.SelectedValue = items.Id.ToString();
                                    aux++;
                                    DDModalEspecialidades3.Visible = true;
                                    Label2.Visible = true;
                                }
                            }
                        }
                    }
                    //fechaNac.Value = item.FechaNacimiento.ToString();
                }
            }
        }


    }
}