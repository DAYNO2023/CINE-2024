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
    
    public partial class tbSucursales
    {
        public int Sucu_Id { get; set; }
        public string Sucu_Descripcion { get; set; }
        public string Sucu_Direccion { get; set; }
        public string Muni_Codigo { get; set; }
        public Nullable<int> Sucu_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Sucu_Fecha_Creacion { get; set; }
        public Nullable<int> Sucu_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Sucu_Fecha_Modificacion { get; set; }
    
        public virtual tbMunicipio tbMunicipio { get; set; }
    }
}