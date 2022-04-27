using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int Idcategoria { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fecharegistro { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
