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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Deportista = new HashSet<Deportista>();
            this.Empresa = new HashSet<Empresa>();
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int id { get; set; }
        public string nick { get; set; }
        public string clave { get; set; }
        public int idTipoUsuario { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<Deportista> Deportista { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
