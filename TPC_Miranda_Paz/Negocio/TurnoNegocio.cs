using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    class TurnoNegocio
    {
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "SELECT T.Id, T.IdEspecialidad, E.Nombre, T.IdMedico, M.Apellido, M.Nombre, M.Matricula, T.IdPaciente, P.Nombre, P.Apellido, P.Dni, P.Email, P.FechaNac, T.FechaHora, ET.Nombre, ET.Id ";
                string From = "FROM Turnos T INNER JOIN EstadosTurnos ET ON T.IdEstado = ET.Id ";
                string Join = "INNER JOIN Especialidades E ON T.IdEspecialidad = E.Id INNER JOIN Medicos M ON T.IdMedico = M.Id INNER JOIN Pacientes P ON T.IdPaciente = P.Id";

                datos.setearConsulta(SelectColum + From + Join);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Especialidad = new Especialidad((string)datos.Lector.GetString(2), (int)datos.Lector.GetInt32(1));
                    aux.Medico = new Medico((int)datos.Lector.GetInt32(3), (string)datos.Lector.GetString(4), (string)datos.Lector.GetString(5), (string)datos.Lector.GetString(6));
                    aux.Paciente = new Paciente((int)datos.Lector.GetInt32(7), (string)datos.Lector.GetString(8), (string)datos.Lector.GetString(9), (string)datos.Lector.GetString(10), (string)datos.Lector.GetString(11), (DateTime)datos.Lector.GetDateTime(12));
                    aux.Fecha = (DateTime)datos.Lector["FechaHora"];
                    aux.Estado = new EstadoTurno((int)datos.Lector.GetInt32(14), (string)datos.Lector.GetString(15));

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

        public void agregar(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Turnos (IdPaciente,IdMedico,FechaHora,IdEstado,IdEspecialidad) VALUES (@idpaciente, @idmedico, @fecha, @dni, @estado, @especialidad)");

                datos.setearParametro("@idpaciente", nuevo.Paciente.Id);
                datos.setearParametro("@idmedico", nuevo.Medico.Id);
                datos.setearParametro("@fecha", nuevo.Fecha);
                datos.setearParametro("@estado", nuevo.Estado.Id);
                datos.setearParametro("@especialidad", nuevo.Especialidad.Id);


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

        public void modificar(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Turnos SET IdPaciente = @idpaciente, IdMedico = @idmedico, FechaHora = @fecha, IdEstado = @estado, IdEspecialidad = @especialidad WHERE Id = @id");
                
                datos.setearParametro("@idpaciente", nuevo.Paciente.Id);
                datos.setearParametro("@idmedico", nuevo.Medico.Id);
                datos.setearParametro("@fecha", nuevo.Fecha);
                datos.setearParametro("@estado", nuevo.Estado.Id);
                datos.setearParametro("@especialidad", nuevo.Especialidad.Id);

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
                datos.setearConsulta("DELETE FROM Turnos WHERE Id = " + id);
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

<--->