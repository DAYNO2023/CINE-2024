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
    
    public partial class tbPantallas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPantallas()
        {
            this.tbPantalla_Roles = new HashSet<tbPantalla_Roles>();
        }
    
        public int Pant_Id { get; set; }
        public string Pant_Descripcion { get; set; }
        public Nullable<bool> Pant_Identificador { get; set; }
        public Nullable<int> Pant_Creacion { get; set; }
        public Nullable<System.DateTime> Pant_Fecha_Creacion { get; set; }
        public Nullable<int> Pant_Modifica { get; set; }
        public Nullable<System.DateTime> Pant_Fecha_Modifica { get; set; }
        public Nullable<bool> Pant_Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPantalla_Roles> tbPantalla_Roles { get; set; }
    }
}
