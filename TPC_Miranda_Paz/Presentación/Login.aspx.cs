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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                //traigo datos del txt
                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;
                //comparo
                if (usuarioNegocio.Loguear(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //msj de error al front
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}