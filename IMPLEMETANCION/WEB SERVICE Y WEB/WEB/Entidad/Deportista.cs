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
    
    public partial class Deportista
    {
        public Deportista()
        {
            this.Amigo = new HashSet<Amigo>();
            this.Amigo1 = new HashSet<Amigo>();
            this.DetalleInvitados = new HashSet<DetalleInvitados>();
            this.Mensaje = new HashSet<Mensaje>();
            this.Mensaje1 = new HashSet<Mensaje>();
            this.SolicitudAmistad = new HashSet<SolicitudAmistad>();
            this.SolicitudAmistad1 = new HashSet<SolicitudAmistad>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int idUsuario { get; set; }
        public int celular { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<Amigo> Amigo { get; set; }
        public virtual ICollection<Amigo> Amigo1 { get; set; }
        public virtual ICollection<DetalleInvitados> DetalleInvitados { get; set; }
        public virtual ICollection<Mensaje> Mensaje { get; set; }
        public virtual ICollection<Mensaje> Mensaje1 { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<SolicitudAmistad> SolicitudAmistad { get; set; }
        public virtual ICollection<SolicitudAmistad> SolicitudAmistad1 { get; set; }
    }
}
