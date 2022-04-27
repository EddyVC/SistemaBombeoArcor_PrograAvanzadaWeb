using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.DAL.DO.Objetos
{
    public partial class Instalador
    {
        public int IdInstalador { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
    }
}
