using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
   public class MedicoNegocio
    {
        public List<Medico> listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            EspecialidadesMedicoNegocio especilidadMedico = new EspecialidadesMedicoNegocio();

            try
            {
                string SelectColum = "SELECT * FROM Medicos ";

                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Martricula = (string)datos.Lector["Matricula"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Password = (string)datos.Lector["Pass"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Especialidades = especilidadMedico.listar(aux);
                    aux.Estado = (bool)datos.Lector["Estado"];
          
                   

                    lista.Add(aux);
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

        public void agregar(Medico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Medicos (Nombre,Apellido,Matricula,Email,Pass,Dni,Telefono, Estado) VALUES (@nombre, @apellido, @matricula, @email, @pass, @dni, @telefono, @estado)");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@matricula", nuevo.Martricula);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Password);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono", nuevo.Telefono);
                datos.setearParametro("@estado", nuevo.Estado);

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

        public void modificar(Medico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Medicos SET Nombre = @nombre, Apellido = @apellido, Matricula = @matricula, Email = @email, Pass = @pass, Dni = @dni, Telefono = @telefono, IdEspecialidad = @especialidad, Estado = @estado WHERE Id = @id");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@matricula", nuevo.Martricula);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Password);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono", nuevo.Telefono);
                //datos.setearParametro("@especialidad", nuevo.Especialidad.Id);
                datos.setearParametro("@estado", nuevo.Estado);

                datos.setearParametro("@id", nuevo.Id);

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
                datos.setearConsulta("DELETE FROM Medicos WHERE Id = " + id);
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

    }
}
