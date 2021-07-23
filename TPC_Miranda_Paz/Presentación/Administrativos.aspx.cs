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
        
        public List<Administrador> listaAdmin;

        public List<Administrador> adminBusqueda;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                listaAdmin = new List<Administrador>();
                
                AdministradoNegocio administradoNegocio = new AdministradoNegocio();
            try
            {
                if (((Dominio.Usuario)Session["user"]).TipoUsuario != 1)
                {
                    Response.Redirect("Error.aspx");
                }

                listaAdmin = administradoNegocio.listar();
                

                if (!IsPostBack)
                {
                    

                    GridAdministradores.DataSource = listaAdmin;
                    GridAdministradores.DataBind();

                    
                    Session.Add("Administradores", listaAdmin);
                }


            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
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

       

        protected void GridAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow devuelto = GridAdministradores.SelectedRow;

            string email = devuelto.Cells[2].Text;

            foreach (Administrador item in listaAdmin)
            {
                if (email == item.Email)
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

      

        protected void GridAdministradores_Load(object sender, EventArgs e)
        {
            GridAdministradores.CssClass = "table table-bordered table-hover";
            GridAdministradores.HeaderStyle.CssClass = "thead-dark";
        }

        protected void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (adminBusqueda == null)
                {
                    adminBusqueda = new List<Administrador>();

                    foreach (Administrador item in listaAdmin)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            adminBusqueda.Add(item);
                        }
                        else
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                adminBusqueda.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    List<Administrador> listaAux = new List<Administrador>();

                    foreach (Administrador item in adminBusqueda)
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
                    adminBusqueda.Clear();
                    adminBusqueda = listaAux;
                }
                GridAdministradores.DataSource = adminBusqueda;
                GridAdministradores.DataBind();

            }
            catch (Exception ex)
            {

                Response.Redirect("Login.aspx");
            }
        }

        

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                AdministradoNegocio administradoNegocio = new AdministradoNegocio();
                administradoNegocio.eliminar(int.Parse(TxtId.Text));
            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Administrativos.aspx");
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                AdministradoNegocio administradoNegocio = new AdministradoNegocio();
                Administrador nuevo = new Administrador();

                nuevo.Id = int.Parse(TxtId.Text);
                nuevo.Nombre = TxtNombre.Text;
                nuevo.Apellido = TxtApellido.Text;
                nuevo.Dni = TxtDNI.Text;
                nuevo.Email = TxtEmail.Text;
                nuevo.Password = TxtPass.Text;
                nuevo.Telefono = TxtTelefono.Text;
                nuevo.Estado = true;

                administradoNegocio.modificar(nuevo);
            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Administrativos.aspx");
        }
    }
}