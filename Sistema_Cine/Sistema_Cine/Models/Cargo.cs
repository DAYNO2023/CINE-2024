using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{


    [MetadataType(typeof(CargoMeta))]
    public partial class tbCargos
    {

    }



    public class CargoMeta
    {
        [Display(Name = "Cargo Id")]
        public int Carg_Id { get; set; }
        [Display(Name = "Cargo:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Carg_Descripcion { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Carg_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha creacion")]
        public Nullable<System.DateTime> Carg_Fecha_Creacion { get; set; }
        [Display(Name = "user Modifica")]
        public Nullable<int> Carg_Usuario_Modificacion { get; set; }
        [Display(Name = "fecha Modifica")]
        public Nullable<System.DateTime> Carg_Fecha_Modificacion { get; set; }






    }
}