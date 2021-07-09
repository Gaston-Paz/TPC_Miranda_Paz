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
                    if((bool)datos.Lector["Estado"] == true)
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
                datos.setearConsulta("UPDATE Medicos SET Nombre = @nombre, Apellido = @apellido, Matricula = @matricula, Email = @email, Pass = @pass, Dni = @dni, Telefono = @telefono, Estado = @estado WHERE Id = @id");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@matricula", nuevo.Martricula);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Password);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono", nuevo.Telefono);
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
                datos.setearConsulta("UPDATE MEDICOS SET ESTADO = 0 WHERE ID = " + id);
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

        public int buscarMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();
            int id=0;

            try
            {
                datos.setearConsulta("select Id from Medicos where Email like @email");
                datos.setearParametro("@email", medico.Email);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    id = (int)datos.Lector["Id"];
                }

                return id;
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

        public int chequear_dni(string dni)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                int x = 0;

                string consulta = "SELECT * FROM MEDICOS WHERE DNI = @dni";

                datos.setearParametro("@dni", dni);
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    x++;
                }

                return x;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public int chequear_email(string email)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                int x = 0;

                string consulta = "SELECT * FROM MEDICOS WHERE EMAIL = @email";

                datos.setearParametro("@email", email);
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    x++;
                }

                return x;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public int chequear_matricula(string matricula)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                int x = 0;

                string consulta = "SELECT * FROM MEDICOS WHERE matricula = @matricula";

                datos.setearParametro("@matricula", matricula);
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    x++;
                }

                return x;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
