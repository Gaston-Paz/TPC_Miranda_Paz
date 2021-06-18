using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    class DisponibilidadMedicoNegocio
    {
        public List<DisponibilidadMedico> listar()
        {
            List<DisponibilidadMedico> lista = new List<DisponibilidadMedico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "SELECT MDD.IdMedico, M.Nombre, M.Apellido, M.Matricula, MDD.IdDia, D.Nombre,MDD.HoraEntrada, MDD.HoraSalida ";
                string From = "FROM MedicosDisponiblesxDia MDD INNER JOIN Medicos M ON MDD.IdMedico = M.Id INNER JOIN Dias D ON D.Id = MDD.IdDia";

                datos.setearConsulta(SelectColum + From);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DisponibilidadMedico aux = new DisponibilidadMedico();
                    aux.Medico = new Medico((int)datos.Lector.GetInt32(0), (string)datos.Lector.GetString(2), (string)datos.Lector.GetString(1), (string)datos.Lector.GetString(3));
                    aux.Entrada = (int)datos.Lector.GetInt32(6);
                    aux.Salida = (int)datos.Lector.GetInt32(7);
                    aux.Dia = new Dia((int)datos.Lector.GetInt32(4), (string)datos.Lector.GetString(5));

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

        public void agregar(DisponibilidadMedico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO MedicosDisponiblesxDia (IdMedico,IdDia,HoraEntrada,HoraSalida) VALUES (@idmedico, @idia, @horaentrada, @horasalida)");

                datos.setearParametro("@idmedico", nuevo.Medico.Id);
                datos.setearParametro("@idia", nuevo.Dia.Id);
                datos.setearParametro("@horaentrada", nuevo.Entrada);
                datos.setearParametro("@horasalida", nuevo.Salida);


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

        public void modificar(DisponibilidadMedico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MedicosDisponiblesxDia SET IdMedico = @idmedico, IdDia = @idia, HoraEntrada = @horaentrada, HoraSalida = @horasalida WHERE IdMedico = @idmedico AND IdDia = idia");

                datos.setearParametro("@idmedico", nuevo.Medico.Id);
                datos.setearParametro("@idia", nuevo.Dia.Id);
                datos.setearParametro("@horaentrada", nuevo.Entrada);
                datos.setearParametro("@horasalida", nuevo.Salida);

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

        public void eliminar(int IdMedico, int idia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM MedicosDisponiblesxDia WHERE WHERE IdMedico = " + IdMedico + " AND IdDia = " + idia);
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
