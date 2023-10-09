using AutoMapper;
using Softtek.Biblioteca.Domain.Entities;
using Softtek.Biblioteca.Domain.Entities.DTOs;

namespace Softtek.Biblioteca.Api.Transversal
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, Domain.Entities.Models.Autor>().ReverseMap();
            CreateMap<Autor, AutorDto>().ReverseMap();
            CreateMap<Libro, Domain.Entities.Models.Libro>().ReverseMap();
            CreateMap<Libro, LibroDto>().ReverseMap();
        }
    }
}
