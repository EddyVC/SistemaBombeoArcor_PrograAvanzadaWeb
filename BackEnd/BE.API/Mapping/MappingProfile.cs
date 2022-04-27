using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = BE.DAL.DO.Objetos;

namespace BE.API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Categoria, DataModels.Categoria>().ReverseMap();
            CreateMap<data.Contacto, DataModels.Contacto>().ReverseMap();
            CreateMap<data.Instalador, DataModels.Instalador>().ReverseMap();
            CreateMap<data.Marca, DataModels.Marca>().ReverseMap();
            CreateMap<data.Provincia, DataModels.Provincia>().ReverseMap();
            CreateMap<data.Producto, DataModels.Producto>().ReverseMap();
        }
    }
}
