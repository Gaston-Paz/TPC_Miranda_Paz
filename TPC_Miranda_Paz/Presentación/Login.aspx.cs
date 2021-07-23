using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Dominio;
using Negocio;

namespace Presentación
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
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
                string[] tablas = new string[]{ "Administradores","Medicos","Recepcionistas" };

                for (int i = 0; i < tablas.Length; i++)
                {
                    Usuario aux = new Usuario();
                    aux = usuarioNegocio.Loguear(user, tablas[i]);
                    if (aux.Email != null)
                    {
                        Session.Add("user", aux);
                        Response.Redirect("Default.aspx");
                    }
                    
                }
                string msj = "Error: Usuario/password incorrectos.";
                //Session.Add("Error", msj);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "Alert('" + msj + "');",true);
                MessageBox.Show(msj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}