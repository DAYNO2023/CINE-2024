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
    
    public partial class tbTipo_Pagos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTipo_Pagos()
        {
            this.tbFacturas_Encabezados = new HashSet<tbFacturas_Encabezados>();
        }
    
        public int Tipo_Id { get; set; }
        public string Tipo_Descripcion { get; set; }
        public Nullable<int> Cate_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Cate_Fecha_Creacion { get; set; }
        public Nullable<int> Cate_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Cate_Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbFacturas_Encabezados> tbFacturas_Encabezados { get; set; }
    }
}
