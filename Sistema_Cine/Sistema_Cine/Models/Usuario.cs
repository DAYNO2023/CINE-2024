using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(UsuarioMeta))]
    public partial class tbUsuarios
    {

    }


    public class UsuarioMeta
    {

        [Display(Name = "Usuario_ID")]
        public int Usua_Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        [RegularExpression("^[a-zA-Z ]+$ El Datos es incorrecto")]
        public string Usua_Nombre { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        [RegularExpression("^[a-zA-Z ]+$ El Datos es incorrecto")]
        public string Usua_Contraseña { get; set; }
        [Display(Name = "Empleado")]
        public Nullable<int> Empl_Id { get; set; }
        [Display(Name = "Pantalla_Role")]
        [Required(ErrorMessage = "El campos {0} es requerido")]

        public Nullable<int> Paro_Id { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Usua_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Usua_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica")]
        public Nullable<int> Usua_Modifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> Usua_Fecha_Modifica { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> Usua_Estado { get; set; }



    }
}