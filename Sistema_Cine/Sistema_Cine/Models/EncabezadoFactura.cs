using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(EncabezadoFacturaMEta))]
    public partial class tbFacturas_Encabezados
    {

    }





    public class EncabezadoFacturaMEta
    {

        [Display(Name = "Encabezado_Factura ")]
        public int Fact_Id { get; set; }
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fact_Fecha { get; set; }
        [Display(Name = "Cliente")]
        public Nullable<int> Clie_Id { get; set; }
        [Display(Name = "Empleados")]
        public Nullable<int> Empl_Id { get; set; }
        [Display(Name = "Tipo De pago")]
        public Nullable<int> Tipo_Id { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Fact_Usua_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Fact_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica")]
        public Nullable<int> Fact_Usua_Modifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> Fact_Fecha_Modifica { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> Fact_Estado { get; set; }

    }
}