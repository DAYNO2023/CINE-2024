using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{
    [MetadataType(typeof(EntradasMeta))]
    public partial class tbEntradas
    {

    }





    public class EntradasMeta
    {

        [Display(Name = "Entrada Id:")]
        public int Entra_Id { get; set; }
        [Display(Name = "Entrada Cantidad:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public Nullable<int> Entra_Cantidad { get; set; }
        [Display(Name = "Salas:")]
        public Nullable<int> Sala_Id { get; set; }
        [Display(Name = "User creacion:")]
        public Nullable<int> Entra_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha creacion:")]
        public Nullable<System.DateTime> Entra_Fecha_Creacion { get; set; }
        [Display(Name = "User  Modifica:")]
        public Nullable<int> Entra_Usuario_Modificacion { get; set; }
        [Display(Name = "fecha Modifica:")]
        public Nullable<System.DateTime> Entra_Fecha_Modificacion { get; set; }







    }
}