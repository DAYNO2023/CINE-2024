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
    
    public partial class tbDepartamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbDepartamentos()
        {
            this.tbMunicipio = new HashSet<tbMunicipio>();
        }
    
        public string Depa_Codigo { get; set; }
        public string Depa_Descripcion { get; set; }
        public Nullable<int> Depa_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Depa_Fecha_Creacion { get; set; }
        public Nullable<int> Depa_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Depa_Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMunicipio> tbMunicipio { get; set; }
    }
}
