//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mensaje
    {
        public int id { get; set; }
        public int idPelotero { get; set; }
        public int idReceptor { get; set; }
        public string descripcion { get; set; }
        public bool visto { get; set; }
        public bool activo { get; set; }
    
        public virtual Deportista Deportista { get; set; }
        public virtual Deportista Deportista1 { get; set; }
    }
}
