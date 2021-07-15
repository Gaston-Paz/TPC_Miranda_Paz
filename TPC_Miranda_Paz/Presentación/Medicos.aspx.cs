﻿using System;
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
        public List<Especialidad> listaEspecialidades2;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                listaMedicos = medicoNegocio.listar();
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                listaEspecialidades = new List<Especialidad>();
                listaEspecialidades2 = new List<Especialidad>();

                List<Especialidad> listaEspecialidadesAux = new List<Especialidad>();

                listaEspecialidadesAux = especialidadNegocio.listar();
                listaEspecialidades.Add(new Especialidad("*Seleccionar", 0));
                listaEspecialidades2 = especialidadNegocio.listar();

                foreach (Especialidad item in listaEspecialidadesAux)
                {
                    listaEspecialidades.Add(item);
                }

                if (!IsPostBack) { 
                    ///CARGO LA GRILLA
                    GridMedicos.DataSource = listaMedicos;
                    GridMedicos.DataBind();
                
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

                    ChecEspecialidades.DataSource = listaEspecialidades2;
                    ChecEspecialidades.DataTextField = "Nombre";
                    ChecEspecialidades.DataValueField = "Id";
                    ChecEspecialidades.DataBind();

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


        protected void BtnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            ///SE MUESTRA UN NUEVO DROP PARA SUMAR ESPECIALIDADES
            if(ListEspecialidades.SelectedValue != "0" && ListEspecialidades2.Visible == false)
            {
                ListEspecialidades2.Visible = true;
            }
            else
            {
                if(ListEspecialidades2.SelectedValue != "0" && ListEspecialidades3.Visible == false)
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
            EspecialidadesMedicoNegocio especialidadesMedicoNegocio = new EspecialidadesMedicoNegocio();
            bool agregar = true;
            

            ///ASIGNO TODAS LAS PROP
            nuevo.Nombre = nombre.Value;
            nuevo.Apellido = apellido.Value;
            nuevo.Dni = dni.Value;
            nuevo.Email = email.Value;
            nuevo.Password = password.Value;
            nuevo.Telefono = telefono.Value;
            nuevo.Martricula = matricula.Value;
            nuevo.Estado = true;
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

            if (medicoNegocio.chequear_dni(nuevo.Dni) > 0)
            {
                /// DNI REPETIDO
                dni.Attributes.Add("class", "form-control is-invalid");
                agregar = false;
            }

            if (medicoNegocio.chequear_email(nuevo.Email) > 0)
            {
                /// EMAIL REPETIDO
                email.Attributes.Add("class", "form-control is-invalid");
                agregar = false;
            }

            if (medicoNegocio.chequear_matricula(nuevo.Martricula) > 0)
            {
                /// MATRICULA REPETIDO
                matricula.Attributes.Add("class", "form-control is-invalid");
                agregar = false;
            }

            if(agregar == true)
            {
                ///GUARDO EN LA DB
                medicoNegocio.agregar(nuevo);
                nuevo.Id = medicoNegocio.buscarMedico(nuevo);
                especialidadesMedicoNegocio.agregar(nuevo.Especialidades, nuevo.Id);

                formClear();
            }
            
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

            GridViewRow devuelto = GridMedicos.SelectedRow;

            string dni = devuelto.Cells[2].Text;

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

                    foreach (Especialidad especialidads in item.Especialidades)
                    {
                        foreach (ListItem items in ChecEspecialidades.Items)
                        {
                            if(especialidads.Id.ToString() == items.Value)
                            {
                                items.Selected = true;
                            }
                        }
                    }

                }
            }
        }

        protected void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (listaFiltrada == null)
                {
                    listaFiltrada = new List<Medico>();

                    foreach (Medico item in listaMedicos)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            listaFiltrada.Add(item);
                        }
                        else
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                listaFiltrada.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    List<Medico> listaAux = new List<Medico>();

                    foreach (Medico item in listaFiltrada)
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
                    listaFiltrada.Clear();
                    listaFiltrada = listaAux;
                }

                GridMedicos.DataSource = listaFiltrada;
                GridMedicos.DataBind();
            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
        }

        protected void formClear()
        {
            nombre.Value = "";
            apellido.Value = "";
            dni.Value = "";
            email.Value = "";
            password.Value = "";
            telefono.Value = "";
            matricula.Value = "";
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ///SE GUARDA UN MEDICO NUEVO AUX
     
                Medico nuevo = new Medico();

                EspecialidadesMedicoNegocio especialidadesMedicoNegocio = new EspecialidadesMedicoNegocio();
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                List<Especialidad> nueva = new List<Especialidad>();

                List<Especialidad> borrar = new List<Especialidad>();
                List<Especialidad> aux = new List<Especialidad>();


                ///ASIGNO TODAS LAS PROP
                nuevo.Id = int.Parse(TxtId.Text);
                nuevo.Nombre = TxtNombre.Text;
                nuevo.Apellido = TxtApellido.Text;
                nuevo.Dni = TxtDNI.Text;
                nuevo.Email = TxtEmail.Text;
                nuevo.Password = TxtPass.Text;
                nuevo.Telefono = TxtTelefono.Text;
                nuevo.Martricula = TxtMatricula.Text;
                nuevo.Estado = true;
                nuevo.Especialidades = new List<Especialidad>();

                foreach (ListItem items in ChecEspecialidades.Items)
                {
                    foreach (Especialidad item in listaEspecialidades)
                    {
                        if (items.Selected){
                            if(items.Value == item.Id.ToString()) {
                            nuevo.Especialidades.Add(item);
                            }
                        }
                    }
                }

                if (medicoNegocio.chequear_email(nuevo.Email) > 0)
                {
                    /// EMAIL REPETIDO
                    TxtEmail.CssClass = "form-control is-invalid";

                }

                    ///GUARDO EN LA DB
                medicoNegocio.modificar(nuevo);

                foreach (Medico item in listaMedicos)
                {
                    if (item.Id == nuevo.Id)
                    {
                        borrar = item.Especialidades;
                    }
                }

                foreach (Especialidad item in nuevo.Especialidades)
                {
                    borrar.Remove(borrar.Find(x => x.Id == item.Id));
                }


                especialidadesMedicoNegocio.eliminar(borrar, nuevo.Id);

                especialidadesMedicoNegocio.agregar(especialidadesMedicoNegocio.chequear_existencia(nuevo), nuevo.Id);



            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
            Response.Redirect("Medicos.aspx");
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtId.Text);
                MedicoNegocio medicoNegocio = new MedicoNegocio();

                medicoNegocio.eliminar(id);

                
            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Medicos.aspx");
        }

      
    }
}