using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(PantallaRolesMEta))]
    public partial class tbPantalla_Roles
    {

    }



    public class PantallaRolesMEta
    {

        [Display(Name = "PantallaRoles_ID")]
        public int Paro_Id { get; set; }
        [Display(Name = "Roles")]
        public Nullable<int> Role_Id { get; set; }
        [Display(Name = "Pantallas")]
        public Nullable<int> Pant_Id { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Pant_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Pant_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica")]
        public Nullable<int> Pant_Modifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> Pant_Fecha_Modifica { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> Pant_Estado { get; set; }

    }
}