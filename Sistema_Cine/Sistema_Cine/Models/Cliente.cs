﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Cine.Models
{


    [MetadataType(typeof(ClienteMeta))]
    public partial class tbClientes
    {

    }


    public class ClienteMeta
    {
        [Display(Name = "Cliente Id:")]
        
        public int Clie_Id { get; set; }
        [Display(Name = "Cliente Nombre:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Clie_Nombre { get; set; }
        [Display(Name = "Cliente Apellido:")]
        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Clie_Apellido { get; set; }
        [Display(Name = "Cliente Identidad:")]

        [Required(ErrorMessage = "El campos {0} es requerido")]
        public string Clie_Identidad { get; set; }
        [Display(Name = "Sexo:")]
        [RegularExpression("[FM]", ErrorMessage = "El sexo debe ser 'F' o 'M'.")]
        public string Clie_Sexo { get; set; }
        [Display(Name = "Telefono:")]
        public Nullable<int> Clie_Telefono { get; set; }
        [Display(Name = "Estado Civil:")]
        public Nullable<int> Esta_Id { get; set; }
        [Display(Name = "Fecha Nacimiento:")]
        public Nullable<System.DateTime> Clie_FecNacimiento { get; set; }
        [Display(Name = "Municipio:")]
        public string Muni_Id { get; set; }
        [Display(Name = "User Creacion:")]
        public Nullable<int> Clie_Usua_Creacion { get; set; }
        [Display(Name = "Fecha Creacion:")]
        public Nullable<System.DateTime> Clie_Fecha_Creacion { get; set; }
        [Display(Name = "User modifica:")]
        public Nullable<int> Clie_Usua_Modifica { get; set; }
        [Display(Name = "Fecha Modifica:")]
        public Nullable<System.DateTime> Clie_Fecha_Modifica { get; set; }
        [Display(Name = "Estado:")]
        public Nullable<bool> Clie_Estado { get; set; }






    }
}