using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Carrito
    {
        public int Idcarrito { get; set; }
        public int Idproducto { get; set; }
        public string Idusuario { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
        public virtual AspNetUsers IdusuarioNavigation { get; set; }
    }
}
