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
        [Display(Name ="Codigo")]
        public string Muni_Codigo { get; set; }
        [Display(Name = "Municipio2")]
        [Required(ErrorMessage ="El campos {0} es requerido")]
        public string Muni_Descripcion { get; set; }
        [Display(Name = "Creacion")]
        public Nullable<int> Muni_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha")]

        public Nullable<System.DateTime> Muni_Fecha_Creacion { get; set; }




    }
}