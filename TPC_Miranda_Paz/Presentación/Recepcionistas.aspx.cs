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
    public partial class Recepcionistas : System.Web.UI.Page
    {

        public List<Recepcionista> recepcionistasBusqueda;
        public List<Recepcionista> listaRecepcionista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Dominio.Usuario)Session["user"]).TipoUsuario == 3)
            {
                Response.Redirect("Error.aspx");
            }

            listaRecepcionista = new List<Recepcionista>();
            RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
            try
            {
                listaRecepcionista = recepcionistaNegocio.listar();
                if (!IsPostBack)
                {
                    GridRecepcionista.DataSource = listaRecepcionista;
                    GridRecepcionista.DataBind();

                    Session.Add("Recepcionistas", listaRecepcionista);
                }
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
        protected void GridRecepcionista_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow devuelto = GridRecepcionista.SelectedRow;

            string email = devuelto.Cells[2].Text;

            foreach (Recepcionista item in listaRecepcionista)
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
        protected void GridRecepcionista_Load1(object sender, EventArgs e)
        {
            GridRecepcionista.CssClass = "table table-bordered table-hover";
            GridRecepcionista.HeaderStyle.CssClass = "thead-dark";
        }

        protected void TxtBuscarRecepcionista_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (recepcionistasBusqueda == null)
                {
                    recepcionistasBusqueda = new List<Recepcionista>();

                    foreach (Recepcionista item in listaRecepcionista)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscarRecepcionista.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            recepcionistasBusqueda.Add(item);
                        }
                        else
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscarRecepcionista.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                recepcionistasBusqueda.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    List<Recepcionista> listaAux = new List<Recepcionista>();

                    foreach (Recepcionista item in recepcionistasBusqueda)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscarRecepcionista.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            listaAux.Add(item);
                        }
                        else
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscarRecepcionista.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                listaAux.Add(item);
                            }
                        }
                    }
                    recepcionistasBusqueda.Clear();
                    recepcionistasBusqueda = listaAux;
                }
                GridRecepcionista.DataSource = recepcionistasBusqueda;
                GridRecepcionista.DataBind();

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
                RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
                recepcionistaNegocio.eliminar(int.Parse(TxtId.Text));
            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Recepcionistas.aspx");
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
                Recepcionista nuevo = new Recepcionista();

                nuevo.Id = int.Parse(TxtId.Text);
                nuevo.Nombre = TxtNombre.Text;
                nuevo.Apellido = TxtApellido.Text;
                nuevo.Dni = TxtDNI.Text;
                nuevo.Email = TxtEmail.Text;
                nuevo.Password = TxtPass.Text;
                nuevo.Telefono = TxtTelefono.Text;
                nuevo.Estado = true;


                recepcionistaNegocio.modificar(nuevo);
            }
            catch (Exception ex)
            {

                throw;
            }
            Response.Redirect("Recepcionistas.aspx");
        }
    }
}