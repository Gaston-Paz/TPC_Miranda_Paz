﻿using System;
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
                string SelectColum = "SELECT Id, Nombre, Apellido, Email, Dni, Telefono, FechaNac FROM Pacientes";


                datos.setearConsulta(SelectColum);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];

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

        public void agregar(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Pacientes (Nombre,Apellido,Email,Dni,Telefono, FechaNac) VALUES (@nombre, @apellido, @email, @dni, @telefono, @fechaNac)");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@fechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono", nuevo.Telefono);

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
                datos.setearConsulta("UPDATE Pacientes SET Nombre = @nombre, Apellido = @apellido, Email = @email, FechaNac = @fechaNac, Dni = @dni, Telefono = @telefono, WHERE Id = @id");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@fechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@telefono", nuevo.Telefono);

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
                datos.setearConsulta("DELETE FROM Pacientes WHERE Id = " + id);
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
