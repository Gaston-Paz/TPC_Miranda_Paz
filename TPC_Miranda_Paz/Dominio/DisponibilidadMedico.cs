using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DisponibilidadMedico
    {
        public Medico Medico { get; set; }

        public int Entrada { get; set; }

        public int Salida { get; set; }

        public Dia Dia { get; set; }

    }
}

