using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Cine.Models
{
    [MetadataType(typeof(DetalleFacturaMEta))]
    public partial class tbFacturas_Detalles
    {

    }


    public class DetalleFacturaMEta
    {

        [Display(Name = "Detalle_Factura ID")]
        public int Fade_Id { get; set; }
        [Display(Name = "Factura Encabezado")]
        public Nullable<int> Fact_Id { get; set; }
        [Display(Name = "Cartelera")]
        public Nullable<int> Cart_Id { get; set; }
        [Display(Name = "Ticket")]

        public Nullable<int> Fade_ticket { get; set; }
        [Display(Name = "User Creacion")]
        public Nullable<int> Fade_Usua_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public Nullable<System.DateTime> Fade_Fecha_Creacion { get; set; }
        [Display(Name = "User Modifica")]
        public Nullable<int> Fade_Usua_Modifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> Fade_Fecha_Modificacion { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> Fade_Estado { get; set; }








    }
}