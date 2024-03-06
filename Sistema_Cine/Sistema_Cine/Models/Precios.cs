using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace Sistema_Cine.Models
{
    [MetadataType(typeof(PreciosMEta))]
    public partial class tbPrecios
    {

    }



    public class PreciosMEta
    {
        [Display(Name = "Precio Id:")]
        public int Prec_Id { get; set; }
        [Display(Name = "Precio:")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El dato debe ser numérico")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public Nullable<decimal> Prec_Descripcion { get; set; }
        [Display(Name = "User creacion:")]
        public Nullable<int> Prec_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Creacion:")]
        public Nullable<System.DateTime> Prec_Fecha_Creacion { get; set; }
        [Display(Name = "user Modifica:")]
        public Nullable<int> Prec_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica:")]
        public Nullable<System.DateTime> Prec_Fecha_Modificacion { get; set; }




    }
}