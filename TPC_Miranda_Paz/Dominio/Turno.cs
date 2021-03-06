using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }

        public EstadoTurno Estado { get; set; }

        public Especialidad Especialidad { get; set; }

        public DateTime Fecha { get; set; }

        public int Horario { get; set; }

        public string Fechas { get; set; }

        public string Observacion { get; set; }
    }
}
