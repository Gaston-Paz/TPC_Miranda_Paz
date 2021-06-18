using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public bool Estado { get; set; }

        public Paciente(int id, string nombre, string apellido, string dni, string email, DateTime fecha)
        {
            Id = id;

            Nombre = nombre;

            Apellido = apellido;

            Dni = dni;

            Email = email;

            FechaNacimiento = fecha;
        }

        public Paciente() { }
    }
}
