using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Detalleventa
    {
        public int Iddetalleventa { get; set; }
        public int? Idventa { get; set; }
        public int? Idproducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Preciounidad { get; set; }
        public decimal? Importetotal { get; set; }
        public decimal? Descuento { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fecharegistro { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
        public virtual Venta IdventaNavigation { get; set; }
    }
}
