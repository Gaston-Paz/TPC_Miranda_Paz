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
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Se debe crear la db de usuario vinculado a los tipos de user
                string SelectColum = "SELECT Email, Pass, Estado from Administradores WHERE Email = @email, Pass = @pass";
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Password);
                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario user = new Usuario();
                    user.Email = (string)datos.Lector["Email"];
                    user.Password = (string)datos.Lector["Pass"];
                    user.Estado = (bool)datos.Lector["Estado"];
                    //falta agregar tipo en la tabla nueva para traer datos
                    return true;
                }

                return false;
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
