using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Telefono { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }
        // props agregadas para verificar user y tipo
        public int TipoUsuario { get; set; }

        public bool Estado { get; set; }

    }
}
