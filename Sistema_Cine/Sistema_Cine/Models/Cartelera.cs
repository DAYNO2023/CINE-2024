using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{
    [MetadataType(typeof(CarteleraMEta))]
    public partial class tbCarteleras
         {

          }


    public class CarteleraMEta
    {
        [Display(Name = "Cartelera ID")]
        public int Cart_Id { get; set; }
        [Display(Name = "Cartelera")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El dato es incorrecto")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Cart_Descripcion { get; set; }
        [Display(Name = "Genero")]
        public Nullable<int> Gene_Id { get; set; }
        [Display(Name = "Promocion")]
        public Nullable<int> Prom_Id { get; set; }
        [Display(Name = "Entradas")]
        public Nullable<int> Entra_Id { get; set; }
        [Display(Name = "Fecha estreno")]
        public Nullable<System.DateTime> Cart_Fecha_Estreno { get; set; }
        [Display(Name = "User creacion")]
        public Nullable<int> Cart_Usuario_Creacion { get; set; }
        [Display(Name = "fecha Creacion")]
        public Nullable<System.DateTime> Cart_Fecha_Creacion { get; set; }
        [Display(Name = "user Modifica")]
        public Nullable<int> Cart_Usuario_Modificacion { get; set; }
        [Display(Name = "fecha Modifica")]
        public Nullable<System.DateTime> Cart_Fecha_Modificacion { get; set; }




    }
}