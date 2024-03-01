using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(DepartamentoMeta))]
    public partial class tbDepartamentos
    {

    }



    public class DepartamentoMeta
    {

        [Display(Name = "CodigoDepa")]
        public string Depa_Codigo { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campos {0} es requerido")]

        public string Depa_Descripcion { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Depa_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Depa_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica")]
        public Nullable<int> Depa_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> Depa_Fecha_Modificacion { get; set; }








    }
}