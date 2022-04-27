using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.DAL.DO.Objetos
{
    public partial class Producto
    {
        public Producto()
        {
            //Carrito = new HashSet<Carrito>();
            //Detalleventa = new HashSet<Detalleventa>();
            //History = new HashSet<History>();
        }

        public int Idproducto { get; set; }
        public string Codigo { get; set; }
        public int? Valorcodigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Idcategoria { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public int? Idmarca { get; set; }

        public virtual Categoria IdcategoriaNavigation { get; set; }
        public virtual Marca IdmarcaNavigation { get; set; }
        //public virtual ICollection<Carrito> Carrito { get; set; }
        //public virtual ICollection<Detalleventa> Detalleventa { get; set; }
        //public virtual ICollection<History> History { get; set; }
    }
}
