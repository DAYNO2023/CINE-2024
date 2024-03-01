using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{


    [MetadataType(typeof(SalasMEta))]
    public partial class tbSalas
    {

    }

    public class SalasMEta
    {
        [Display(Name = "Salas Id")]
        public int Sala_Id { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Sala_Descripcion { get; set; }
        [Display(Name = "Butacas")]
        public Nullable<int> Buta_Id { get; set; }
        [Display(Name = "User creacion:")]
        public Nullable<int> Cate_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Creacion:")]
        public Nullable<System.DateTime> Cate_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica:")]
        public Nullable<int> Cate_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica:")]
        public Nullable<System.DateTime> Cate_Fecha_Modificacion { get; set; }




    }
}