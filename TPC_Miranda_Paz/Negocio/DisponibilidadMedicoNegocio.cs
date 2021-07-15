using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DisponibilidadMedicoNegocio
    {
        public List<DisponibilidadMedico> listar(int id)
        {
            List<DisponibilidadMedico> lista = new List<DisponibilidadMedico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "select * from MedicosDisponiblesxDia MDD inner join Dias D on d.Id = MDD.IdDia where IdMedico = @idMedico";
                datos.setearConsulta(SelectColum);
                datos.setearParametro("@idMedico", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DisponibilidadMedico aux = new DisponibilidadMedico();
                    aux.IdMedico = id;
                    aux.Entrada = (int)datos.Lector.GetInt32(2);
                    aux.Salida = (int)datos.Lector.GetInt32(3);
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

        public void agregar(List<DisponibilidadMedico> nueva)
        {
            try
            {
                foreach (DisponibilidadMedico item in nueva)
                {
                    AccesoDatos datos = new AccesoDatos();
                    datos.setearConsulta("INSERT INTO MedicosDisponiblesxDia (IdMedico,IdDia,HoraEntrada,HoraSalida) VALUES (@idmedico, @idia, @horaentrada, @horasalida)");

                    datos.setearParametro("@idmedico", item.IdMedico);
                    datos.setearParametro("@idia", item.Dia.Id);
                    datos.setearParametro("@horaentrada", item.Entrada);
                    datos.setearParametro("@horasalida", item.Salida);


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

        public void eliminar(int IdMedico)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM MedicosDisponiblesxDia WHERE IdMedico = @idMedico");
                datos.setearParametro("@idMedico", IdMedico);
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
