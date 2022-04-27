using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Factura
    {
        public decimal Idfactura { get; set; }
        public DateTime Fecha { get; set; }
        public float Iva { get; set; }
        public float Total { get; set; }
        public int Numpago { get; set; }
        public decimal? Descuento { get; set; }
    }
}
