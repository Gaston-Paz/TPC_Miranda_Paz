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
            try
            {
                listaRecepcionista = new List<Recepcionista>();
                listaAdmin = new List<Administrador>();
                RecepcionistaNegocio recepcionistaNegocio = new RecepcionistaNegocio();
                AdministradoNegocio administradoNegocio = new AdministradoNegocio();

                listaAdmin = administradoNegocio.listar();
                listaRecepcionista = recepcionistaNegocio.listar();

                Session.Add("Recepcionistas", recepcionistaNegocio);
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
            int x = 1;
        }
    }
}