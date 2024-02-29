using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{
    [MetadataType(typeof(RolesMeta))]
    public partial class tbRoles
    {

    }



    public class RolesMeta
    {

        [Display(Name = "Role_ID")]
        public int Role_Id { get; set; }
        [Display(Name = "Descripcion")]
        public string Role_Descripcion { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Role_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Role_Fecha_Creacion { get; set; }
        [Display(Name = "User Modificar")]
        public Nullable<int> Role_Modifica { get; set; }
        [Display(Name = "Fecha Modificar")]
        public Nullable<System.DateTime> Role_Fecha_Modifica { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> Role_Estado { get; set; }

    }
}