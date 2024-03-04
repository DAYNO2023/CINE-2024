using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Sistema_Cine.Models
{


    [MetadataType(typeof(ButacasSalasMeta))]
    public partial class tbButacas_Salas
    {

    }
        





    public class ButacasSalasMeta
    {

        [Display(Name = "Butacas_ID")]
        public int Buta_Id { get; set; }

        [Display(Name = "Butacas Cantidad:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Buta_Descripcion { get; set; }

        [Display(Name = "Usuario Creacion")]
        public Nullable<int> Buta_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]

        public Nullable<System.DateTime> Buta_Fecha_Creacion { get; set; }
        [Display(Name = "Usuario Modifica")]

        public Nullable<int> Buta_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica")]

        public Nullable<System.DateTime> Buta_Fecha_Modificacion { get; set; }


    }
}