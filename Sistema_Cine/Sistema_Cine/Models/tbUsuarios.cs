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
    
    public partial class tbUsuarios
    {
        public int Usua_Id { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Contraseña { get; set; }
        public Nullable<int> Empl_Id { get; set; }
        public Nullable<int> Paro_Id { get; set; }
        public Nullable<int> Usua_Creacion { get; set; }
        public Nullable<System.DateTime> Usua_Fecha_Creacion { get; set; }
        public Nullable<int> Usua_Modifica { get; set; }
        public Nullable<System.DateTime> Usua_Fecha_Modifica { get; set; }
        public Nullable<bool> Usua_Estado { get; set; }
    
        public virtual tbPantalla_Roles tbPantalla_Roles { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
    }
}