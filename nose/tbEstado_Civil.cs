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
    
    public partial class tbEstado_Civil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEstado_Civil()
        {
            this.tbClientes = new HashSet<tbClientes>();
            this.tbEmpleado = new HashSet<tbEmpleado>();
        }
    
        public int Esta_Id { get; set; }
        public string Esta_Descripcion { get; set; }
        public Nullable<int> Esta_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Esta_Fecha_Creacion { get; set; }
        public Nullable<int> Esta_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Esta_Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbClientes> tbClientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleado> tbEmpleado { get; set; }
    }
}