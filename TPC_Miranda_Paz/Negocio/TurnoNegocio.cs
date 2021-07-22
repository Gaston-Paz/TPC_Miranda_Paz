using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar_turnos_ocupados()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "SELECT * FROM Turnos T INNER JOIN EstadosTurnos ET ON T.IdEstado = ET.Id " + 
                                      "INNER JOIN Pacientes P ON T.IdPaciente = P.Id " + "INNER JOIN Medicos M ON T.IdMedico = M.Id " +
                                        "INNER JOIN Especialidades E ON T.IdEspecialidad = E.ID";
                
                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)datos.Lector.GetInt32(10);
                    aux.Paciente.Nombre = (string)datos.Lector.GetString(11);
                    aux.Paciente.Apellido = (string)datos.Lector.GetString(12);
                    aux.Paciente.Dni = (string)datos.Lector.GetString(13);
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)datos.Lector.GetInt32(18);
                    aux.Medico.Nombre = (string)datos.Lector.GetString(19);
                    aux.Medico.Apellido = (string)datos.Lector.GetString(20);
                    aux.Medico.Email = (string)datos.Lector.GetString(22);
                    aux.Fecha = (DateTime)datos.Lector["FechaHora"];
                    aux.Horario = (int)datos.Lector["Horario"];
                    aux.Estado = new EstadoTurno();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["Nombre"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IdEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector.GetString(29);
                    aux.Observacion = (string)datos.Lector["Observacion"];

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
                datos.setearConsulta("INSERT INTO Turnos (IdPaciente,IdMedico,FechaHora,Horario,IdEstado,IdEspecialidad) " +
                                            "VALUES (@idpaciente, @idmedico, @fecha, @hora, @estado, @especialidad)");

                datos.setearParametro("@idpaciente", nuevo.Paciente.Id);
                datos.setearParametro("@idmedico", nuevo.Medico.Id);
                datos.setearParametro("@fecha", nuevo.Fecha);
                datos.setearParametro("@hora", nuevo.Horario);
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

        public void Modificar(int id, int estado, string observacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Turnos SET IdEstado = @estado, Observacion = @observacion WHERE Id = @id");
                datos.setearParametro("@observacion", observacion);
                datos.setearParametro("@estado", estado);
                datos.setearParametro("@id", id);

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

        public List<Turno> turnos_ocupado_especialidad_fecha(int IdEspecilidad, int idMedico, DateTime Fecha)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select * from Turnos where IdEspecialidad = @idEspecialidad and IdMedico = @idMedico AND FechaHora = @fecha";
                datos.setearConsulta(consulta);
                datos.setearParametro("@idEspecialidad", IdEspecilidad);
                datos.setearParametro("@idMedico", idMedico);
                datos.setearParametro("@fecha", Fecha);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)datos.Lector["IdPaciente"];
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)datos.Lector["IdMedico"];
                    aux.Fecha = (DateTime)datos.Lector["FechaHora"];
                    aux.Horario = (int)datos.Lector["Horario"];
                    aux.Estado = new EstadoTurno();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IdEspecialidad"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EstadoTurno> listarEstados()
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                List<EstadoTurno> estadoTurnos = new List<EstadoTurno>();

                string consulta = "Select * from EstadosTurnos";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    EstadoTurno estadoTurno = new EstadoTurno();
                    estadoTurno.Id = (int)datos.Lector["Id"];
                    estadoTurno.Nombre = (string)datos.Lector["Nombre"];
                    estadoTurnos.Add(estadoTurno);
                       
                }
                return estadoTurnos;
            }
            catch (Exception ex)
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

