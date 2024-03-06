using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Sistema_Cine.Models
{

    [MetadataType(typeof(PromocionesMEta))]
    public partial class tbPromociones
    {

    }


    public class PromocionesMEta
    {
        [Display(Name = "Promociones Id:")]
        public int Prom_Id { get; set; }
        [Display(Name = "Descuentos:")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El dato debe ser numérico")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public Nullable<decimal> Prom_Descuento { get; set; }
        [Display(Name = "Promociones:")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El dato es incorrecto")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Prom_Descripcion { get; set; }
        [Display(Name = "Precio Id:")]

        public Nullable<int> Prec_Id { get; set; }
        [Display(Name = "User creacion:")]

        public Nullable<int> Prom_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Cracion:")]

        public Nullable<System.DateTime> Prom_Fecha_Creacion { get; set; }
        [Display(Name = "User Modificacion:")]

        public Nullable<int> Prom_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica:")]

        public Nullable<System.DateTime> Prom_Fecha_Modificacion { get; set; }





    }
}