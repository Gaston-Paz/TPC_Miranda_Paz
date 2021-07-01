using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    class EspecialidadesMedicoNegocio
    {
        public List<Especialidad> listar(Medico aux)
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string SelectColum = "SELECT EM.IdEspecialidad, E.Nombre FROM EspecialidadesxMedico EM INNER JOIN Especialidades E ON EM.IdEspecialidad = E.ID WHERE EM.IdMedico = @idMedico";
                datos.setearParametro("@idMedico", aux.Id);
                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad auxi = new Especialidad();
                    auxi.Id = datos.Lector.GetInt32(0);
                    auxi.Nombre = (string)datos.Lector.GetString(1);

                    lista.Add(auxi);
                }
                return lista;
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

        //public void agregar(Especialidad nuevo)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearConsulta("INSERT INTO Especialidades (Nombre) VALUES (@nombre)");

        //        datos.setearParametro("@nombre", nuevo.Nombre);

        //        datos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        //public void modificar(Especialidad nuevo)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearConsulta("UPDATE Especialidades SET Nombre = @nombre WHERE Id = @id");

        //        datos.setearParametro("@nombre", nuevo.Nombre);
        //        datos.setearParametro("@id", nuevo.Id);

        //        datos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        //public void eliminar(int id)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("DELETE FROM Especialidades WHERE Id = " + id);
        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
    }
}
