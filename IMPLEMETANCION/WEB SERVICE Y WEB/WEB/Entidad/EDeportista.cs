using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EDeportista
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int idUsuario { get; set; }
        public int celular { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
    }
}
