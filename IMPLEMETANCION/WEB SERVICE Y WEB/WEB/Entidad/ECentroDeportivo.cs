using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ECentroDeportivo
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public bool balon { get; set; }
        public bool camisetas { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}
