//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Cine.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbPromociones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPromociones()
        {
            this.tbGeneros = new HashSet<tbGeneros>();
        }
    
        public int Prom_Id { get; set; }
        public Nullable<decimal> Prom_Descuento { get; set; }
        public string Prom_Descripcion { get; set; }
        public Nullable<int> Prom_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Prom_Fecha_Creacion { get; set; }
        public Nullable<int> Prom_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Prom_Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbGeneros> tbGeneros { get; set; }
    }
}
