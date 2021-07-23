using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Loguear(Usuario usuario, string tabla)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario user = new Usuario();
            try
            {
                //Se debe crear la db de usuario vinculado a los tipos de user
                string SelectColum = "SELECT Email, Pass, Estado, Tipo FROM " + tabla + " WHERE Email = @email and Pass = @pass";
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Password);
                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    user.Email = (string)datos.Lector["Email"];
                    user.Password = (string)datos.Lector["Pass"];
                    user.Estado = (bool)datos.Lector["Estado"];
                    user.TipoUsuario = (int)datos.Lector["Tipo"];
                    //falta agregar tipo en la tabla nueva para traer datos
                    return user;
                }

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
