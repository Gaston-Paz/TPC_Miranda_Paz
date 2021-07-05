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
    public partial class Administrativos : System.Web.UI.Page
    {
        public List<Recepcionista> listaRecepcionista;
        public List<Administrador> listaAdmin;
        protected void Page_Load(object sender, EventArgs e)
        {
                listaRecepcionista = new List<Recepcionista>();
                listaAdmin = new List<Administrador>();
                RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
                AdministradoNegocio administradoNegocio = new AdministradoNegocio();
            try
            {

                listaAdmin = administradoNegocio.listar();
                listaRecepcionista = recepcionistaNegocio.listar();

                Session.Add("Recepcionistas", listaRecepcionista);
                    Session.Add("Administradores", listaAdmin);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void BtnRegistrar_Recepcionista_Click(object sender, EventArgs e)
        {
            bool agregar = true;
            Recepcionista nuevo = new Recepcionista();
            RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
            try
            {
                nuevo.Nombre = nombre_recep.Value;
                nuevo.Apellido = apellido_recep.Value;
                nuevo.Dni = dni_recep.Value;
                nuevo.Email = email_recep.Value;
                nuevo.Telefono = telefono_recep.Value;
                nuevo.Password = pass_recep.Value;
                nuevo.Estado = true;

                Session.Add("Recepcionista", nuevo);

                if (recepcionistaNegocio.chequear_dni(nuevo.Dni) > 0)
                {
                    /// DNI REPETIDO
                    //dni.Attributes["class"] = "is-invalid";
                    dni_recep.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }

                if (recepcionistaNegocio.chequear_email(nuevo.Email) > 0)
                {
                    email_recep.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }




            }
            catch (Exception ex)
            {

                throw;
            }
            if (agregar == true)
            {
                recepcionistaNegocio.agregar(nuevo);
                Session.Remove("Recepcionista");
                Response.Redirect("Administrativos.aspx");

            }
        }

        protected void Btn_Registar_admin_Click(object sender, EventArgs e)
        {
            bool agregar = true;
            Administrador nuevo = new Administrador();
            AdministradoNegocio administradoNegocio = new AdministradoNegocio();
            try
            {
                nuevo.Nombre = nombre_admin.Value;
                nuevo.Apellido = apellido_admin.Value;
                nuevo.Dni = dni_admin.Value;
                nuevo.Email = email_admin.Value;
                nuevo.Telefono = telefono_admin.Value;
                nuevo.Password = pass_admin.Value;
                nuevo.Estado = true;

                Session.Add("Administrador", nuevo);

                if (administradoNegocio.chequear_dni(nuevo.Dni) > 0)
                {
                    /// DNI REPETIDO
                    //dni.Attributes["class"] = "is-invalid";
                    dni_admin.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }

                if (administradoNegocio.chequear_email(nuevo.Email) > 0)
                {
                    email_admin.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }




            }
            catch (Exception ex)
            {

                throw;
            }
            if (agregar == true)
            {
                administradoNegocio.agregar(nuevo);
                Session.Remove("Administrador");
                Response.Redirect("Administrativos.aspx");

            }
        }

        protected void GridRecepcionista_Load(object sender, EventArgs e)
        {
            GridRecepcionista.CssClass = "table table-bordered table-hover";
            GridRecepcionista.HeaderStyle.CssClass = "thead-dark";
        }

        protected void GridRecepcionista_SelectedIndexChanged(object sender, EventArgs e)
        {
    
                int index = GridRecepcionista.SelectedIndex;

            GridViewRow devuelto = GridRecepcionista.SelectedRow;

            string dni = devuelto.Cells[3].Text;

            foreach (Recepcionista item in listaRecepcionista)
            {
                if (dni == item.Dni)
                {
                    /// CARGO LOS TEXT DEL MODAL
                    TxtId.Text = item.Id.ToString();
                    TxtNombre.Text = item.Nombre;
                    TxtApellido.Text = item.Apellido;
                    TxtDNI.Text = item.Dni;
                    TxtEmail.Text = item.Email;
                    TxtTelefono.Text = item.Telefono;
                    TxtPass.Text = item.Password;
                }
            }


        }

        protected void GridAdmin_Load(object sender, EventArgs e)
        {
            GridAdmin.CssClass = "table table-bordered table-hover";
            GridAdmin.HeaderStyle.CssClass = "thead-dark";
        }

        protected void GridAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridAdmin.SelectedIndex;

            GridViewRow devuelto = GridAdmin.SelectedRow;

            string dni = devuelto.Cells[3].Text;

            foreach (Administrador item in listaAdmin)
            {
                if (dni == item.Dni)
                {
                    /// CARGO LOS TEXT DEL MODAL
                    TxtId.Text = item.Id.ToString();
                    TxtNombre.Text = item.Nombre;
                    TxtApellido.Text = item.Apellido;
                    TxtDNI.Text = item.Dni;
                    TxtEmail.Text = item.Email;
                    TxtTelefono.Text = item.Telefono;
                    TxtPass.Text = item.Password;
                    
                }
            }
        }

    }
}