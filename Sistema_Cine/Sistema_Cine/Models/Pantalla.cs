using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(PantallaMEta))]
    public partial class tbPantallas
    {

    }


    public class PantallaMEta
    {

        [Display(Name = "Pantalla_ID")]
        public int Pant_Id { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Pant_Descripcion { get; set; }
        [Display(Name = "Identificador")]
        public Nullable<bool> Pant_Identificador { get; set; }
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