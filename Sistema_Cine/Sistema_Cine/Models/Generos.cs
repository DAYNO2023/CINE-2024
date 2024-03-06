using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(GenerosMeta))]
    public partial class tbGeneros
    {

    }



    public class GenerosMeta
    {
        [Display(Name = "Genero Id:")]
        public int Gene_Id { get; set; }
        [Display(Name = "Genero:")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El dato es incorrecto")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Gene_Descripcion { get; set; }
        [Display(Name = "Promocion:")]

        public Nullable<int> Prom_Id { get; set; }
        [Display(Name = "User creacion:")]

        public Nullable<int> Gene_Usuario_Creacion { get; set; }
        [Display(Name = "fecha Creacion:")]

        public Nullable<System.DateTime> Gene_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica:")]

        public Nullable<int> Gene_Usuario_Modificacion { get; set; }
        [Display(Name = "fecha Modifica:")]

        public Nullable<System.DateTime> Gene_Fecha_Modificacion { get; set; }




    }
}