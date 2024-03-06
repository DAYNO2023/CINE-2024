using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{

    [MetadataType(typeof(EmpleadosMeta))]
    public partial class tbEmpleados
    {

    }

    public class EmpleadosMeta
    {
        [Display(Name = "Empleado Id:")]
        public int Empl_Id { get; set; }
        [Display(Name = "Nombre Completo:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Empl_Nombre { get; set; }
      
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Empl_Apellido { get; set; }
        [Display(Name = "Empleado DNI:")]
        [RegularExpression("^[0-9]+$", ErrorMessage = " El Datos es incorrecto")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Empl_Identidad { get; set; }
        [Display(Name = "Sexo:")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = " El Datos es incorrecto")]

        public string Empl_Sexo { get; set; }
        [Display(Name = "Telefono:")]
        [RegularExpression("^[0-9]+$", ErrorMessage = " El Datos es incorrecto")]
        public Nullable<int> Empl_Telefono { get; set; }
        [Display(Name = "Estado Civil:")]
       
        public Nullable<int> Esta_Id { get; set; }
        [Display(Name = "Fecha Nacimiento:")]
        public Nullable<System.DateTime> Empl_FecNacimiento { get; set; }
        [Display(Name = "Municipio:")]
        public string Muni_Id { get; set; }
        [Display(Name = "Cargo:")]
        public Nullable<int> Carg_Id { get; set; }
        [Display(Name = "User creacion:")]
        public Nullable<int> Empl_Usua_Creacion { get; set; }
        [Display(Name = "Fecha Creacion:")]
        public Nullable<System.DateTime> Empl_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica:")]
        public Nullable<int> Empl_Usua_Modifica { get; set; }
        [Display(Name = "Fecha Modifica:")]
        public Nullable<System.DateTime> Empl_Fecha_Modifica { get; set; }
        [Display(Name = "Estado:")]
        public Nullable<bool> Empl_Estado { get; set; }



    }
}