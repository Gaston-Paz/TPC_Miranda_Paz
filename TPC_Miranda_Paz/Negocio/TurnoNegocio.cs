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
                string SelectColum = "select * from Turnos";
                
                datos.setearConsulta(SelectColum);
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

