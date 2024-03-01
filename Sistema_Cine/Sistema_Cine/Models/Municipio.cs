using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{
    [MetadataType(typeof(MunicipioMeta))]
    public partial class tbMunicipio
    {

    }



    public class MunicipioMeta
    {


        [Display(Name = "Codigo")]
        public string Muni_Codigo { get; set; }
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Muni_Descripcion { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Depa_Codigo { get; set; }
        public Nullable<int> Muni_Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Muni_Fecha_Creacion { get; set; }
        public Nullable<int> Muni_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Muni_Fecha_Modificacion { get; set; }




    }
}