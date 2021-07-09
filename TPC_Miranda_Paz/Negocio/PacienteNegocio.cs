using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "SELECT Id, Nombre, Apellido, Email, Dni, Telefono, FechaNac, Estado FROM Pacientes";


                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if((bool)datos.Lector["Estado"] == true) { 
                    Paciente aux = new Paciente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
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

        public void agregar(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" INSERT INTO Pacientes (Nombre,Apellido,Email,Dni,Telefono, FechaNac ,Estado) VALUES (@nombre, @apellido, @email, @dni, @telefono, @fechaNac, @estado) ");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@fechaNac", nuevo.FechaNacimiento);
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

        public void modificar(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Pacientes SET Nombre = @nombre, Apellido = @apellido, Email = @email, FechaNac = @fechaNac, Dni = @dni, Telefono = @telefono, Estado = @estado WHERE Id = @id");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@fechaNac", nuevo.FechaNacimiento);
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
                datos.setearConsulta("UPDATE Pacientes SET ESTADO = 0 WHERE Id = " + id);
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

        public int chequear_dni(string dni)
        {

                AccesoDatos datos = new AccesoDatos();
            try
            {

                int x = 0;

                string consulta = "SELECT * FROM PACIENTES WHERE DNI = @dni";
                
                datos.setearParametro("@dni", dni);
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read()) {

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

                string consulta = "SELECT * FROM PACIENTES WHERE EMAIL = @email";

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

    }
}
