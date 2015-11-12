using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ESolicitudAmistad
    {
        public int id { get; set; }
        public System.DateTime fechaHora { get; set; }
        public bool activo { get; set; }
        public int idPelotero { get; set; }
        public int idReceptor { get; set; }
        public string estado { get; set; }
        public EDeportista Pelotero { get; set; }
    }
}
