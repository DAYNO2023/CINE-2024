using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(SucursalesMEta))]
    public partial class tbSucursales
    {

    }



    public class SucursalesMEta
    {
        [Display(Name = "Sucursales Id:")]
        public int Sucu_Id { get; set; }
        [Display(Name = "Descripcion :")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Sucu_Descripcion { get; set; }
        [Display(Name = "Direccion:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Sucu_Direccion { get; set; }
        [Display(Name = "Municipio :")]
        public string Muni_Codigo { get; set; }
        [Display(Name = "Cartelera :")]
        public Nullable<int> Cart_Id { get; set; }
        [Display(Name = "Entradas:")]
        public Nullable<int> Entra_Id { get; set; }
        [Display(Name = "User Creacion:")]
        public Nullable<int> Sucu_Usuario_Creacion { get; set; }
        [Display(Name = "Fecha Creacion:")]
        public Nullable<System.DateTime> Sucu_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica:")]
        public Nullable<int> Sucu_Usuario_Modificacion { get; set; }
        [Display(Name = "Fecha Modifica:")]
        public Nullable<System.DateTime> Sucu_Fecha_Modificacion { get; set; }



    }
}