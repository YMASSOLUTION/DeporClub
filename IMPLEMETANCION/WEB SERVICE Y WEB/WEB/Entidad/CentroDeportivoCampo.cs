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
    
    public partial class CentroDeportivoCampo
    {
        public int id { get; set; }
        public Nullable<int> idCentroDeportivo { get; set; }
        public Nullable<int> idCancha { get; set; }
    
        public virtual CentroDeportivo CentroDeportivo { get; set; }
        public virtual Campo Campo { get; set; }
    }
}
