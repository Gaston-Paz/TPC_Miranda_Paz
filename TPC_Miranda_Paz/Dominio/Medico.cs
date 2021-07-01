using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Usuario
    {
        public int Id { get; set; }

        public List<Especialidad> Especialidades { get; set; }

        public string Martricula { get; set; }

        public bool Estado { get; set; }

        public Medico(int id, string apellido, string nombre, string matricula)
        {
            Id = id;

            Apellido = apellido;

            Nombre = nombre;

            Martricula = matricula;
        }
     
        public Medico() { }

    }
}
