using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.API.DataModels
{
    public partial class Venta
    {
        public Venta()
        {
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Idventa { get; set; }
        public int? Iva { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Fecharegistro { get; set; }

        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
