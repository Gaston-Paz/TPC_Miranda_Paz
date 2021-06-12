using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Usuario
    {

        public Especialidad Especialidad { get; set; }

        public string Martricula { get; set; }

        public int Id { get; set; }

        public bool[] Agenda { get; set; }
       

    }
}
