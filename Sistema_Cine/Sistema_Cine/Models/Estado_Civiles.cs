using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(Estado_CivilesMEta))]
    public partial class tbEstado_Civil
    {

    }



    public class Estado_CivilesMEta
    {

        [Display(Name = "EstadoCivil ID")]

        public int Esta_Id { get; set; }
        [Display(Name = "Estado Civil")]
        [RegularExpression("^[a-zA-Z ]+$ El Datos es incorrecto")]
        public string Esta_Descripcion { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Esta_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Esta_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica")]
        public Nullable<int> Esta_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> Esta_Fecha_Modificacion { get; set; }




    }
}