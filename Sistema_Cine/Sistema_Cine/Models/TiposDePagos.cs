using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Sistema_Cine.Models
{
    [MetadataType(typeof(TiposDePagosMEta))]
    public partial class tbTipo_Pagos
    {

    }

    public class TiposDePagosMEta
    {



        [Display(Name = "Tipos de Pago Id:")]
        public int Tipo_Id { get; set; }
        [Display(Name = "TipoDePago :")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El dato es incorrecto")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Tipo_Descripcion { get; set; }
        [Display(Name = "User Creacion :")]
        public Nullable<int> Cate_Usuario_Creacion { get; set; }
        [Display(Name = "fecha Creacion :")]
        public Nullable<System.DateTime> Cate_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica :")]
        public Nullable<int> Cate_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha modifica :")]
        public Nullable<System.DateTime> Cate_Fecha_Modificacion { get; set; }








    }
}