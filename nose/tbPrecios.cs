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
    
    public partial class tbPrecios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPrecios()
        {
            this.tbCarteleras = new HashSet<tbCarteleras>();
        }
    
        public int Prec_Id { get; set; }
        public Nullable<decimal> Prec_Descripcion { get; set; }
        public Nullable<int> Prec_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Prec_Fecha_Creacion { get; set; }
        public Nullable<int> Prec_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Prec_Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCarteleras> tbCarteleras { get; set; }
    }
}