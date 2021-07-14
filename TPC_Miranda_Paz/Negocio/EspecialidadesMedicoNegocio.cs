using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EspecialidadesMedicoNegocio
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

        public void agregar(List<Especialidad> nuevo,int id)
        {
            
            try
            {

                foreach (Especialidad item in nuevo)
                {
                    AccesoDatos datos = new AccesoDatos();
                    datos.setearConsulta("INSERT INTO EspecialidadesxMedico (IdEspecialidad, IdMedico) VALUES (@especialidad, @medico)");
                    datos.setearParametro("@especialidad",item.Id);
                    datos.setearParametro("@medico", id);

                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }

        public void modificar(Especialidad nuevo, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE EspecialidadesxMedico SET IdEspecialidad = @idespecialidad WHERE IdMedico = @idmedico");

                datos.setearParametro("@idespecialidad", nuevo.Id);
                datos.setearParametro("@idmedico", id);

                datos.ejecutarAccion();

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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Especialidades WHERE Id = " + id);
                datos.ejecutarAccion();
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

        public List<Especialidad> chequear_existencia(Medico achequear)
        {
            List<Especialidad> agregar = new List<Especialidad>();
            try
            {

                foreach (Especialidad item in achequear.Especialidades)
                {
                    AccesoDatos datos = new AccesoDatos();
                    datos.setearConsulta("select IdEspecialidad from EspecialidadesxMedico where IdMedico = @id and IdEspecialidad = @idespeciadlida");
                    datos.setearParametro("@id", achequear.Id);
                    datos.setearParametro("@idespeciadlida", item.Id);
                    datos.ejecutarLectura();

                    if (!datos.Lector.Read())
                    {
                        agregar.Add(item);
                    }
                    datos.cerrarConexion();
                }
                return agregar;
                
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                
            }
        }
    }
}
