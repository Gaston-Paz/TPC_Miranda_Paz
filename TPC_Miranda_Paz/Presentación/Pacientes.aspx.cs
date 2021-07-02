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
    public partial class Pacientes : System.Web.UI.Page
    {
        public List<Paciente> listaPacientes;
 
        protected void Page_Load(object sender, EventArgs e)
        {                        
            try
            {
                
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                listaPacientes = pacienteNegocio.listar();

                Session.Add("Pacientes", listaPacientes);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

       

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool agregar = true;
            Paciente nuevo = new Paciente();
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            try
            {
                nuevo.Nombre = nombre.Value;
                nuevo.Apellido = apellido.Value;
                nuevo.Dni = dni.Value;
                nuevo.Email = email.Value;
                nuevo.FechaNacimiento = DateTime.Parse(fechaNacimiento.Value);
                nuevo.Telefono = telefono.Value;
                nuevo.Estado = true;

                Session.Add("Paciente", nuevo);

                if (pacienteNegocio.chequear_dni(nuevo.Dni) > 0)
                {
                    /// DNI REPETIDO
                    //dni.Attributes["class"] = "is-invalid";
                    dni.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }
            
                if (pacienteNegocio.chequear_email(nuevo.Email) > 0)
                {
                    email.Attributes.Add("class", "form-control is-invalid");
                    agregar = false;
                }

                


            }
            catch (Exception ex)
            {

                throw;
            }
            if (agregar == true)
            {
                pacienteNegocio.agregar(nuevo);
                Session.Remove("Paciente");
                Response.Redirect("Pacientes.aspx");

            }
        }

        
        public List<Paciente> listaBusqueda = new List<Paciente>();
        
        //protected void TextBox1_TextChanged(object sender, EventArgs e)
        //{
            
        //    List<Paciente> aux = (List<Paciente>)Session["Pacientes"];

        //    foreach (Paciente item in aux)
        //    {
        //        if (System.Text.RegularExpressions.Regex.IsMatch(item.Nombre, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        //        {
        //            listaBusqueda.Add(item);
        //        }
        //        else
        //        {
        //            if (System.Text.RegularExpressions.Regex.IsMatch(item.Apellido, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        //            {
        //                listaBusqueda.Add(item);
        //            }
        //            else
        //            {
        //                if (System.Text.RegularExpressions.Regex.IsMatch(item.Dni, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        //                {
        //                    listaBusqueda.Add(item);
        //                }
        //                else
        //                {
        //                    if (System.Text.RegularExpressions.Regex.IsMatch(item.Email, TxtBuscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        //                    {
        //                        listaBusqueda.Add(item);
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    Response.Redirect("Pacientes.aspx");
        //}
    }
}