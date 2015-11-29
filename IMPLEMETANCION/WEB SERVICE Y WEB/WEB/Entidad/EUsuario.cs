using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EUsuario
    {
        public int id { get; set; }
        public string nick { get; set; }
        public string clave { get; set; }
        public int idTipoUsuario { get; set; }
        public bool activo { get; set; }
        public int idDeportista { get; set; }
    }
}
