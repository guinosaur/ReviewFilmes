using AutoMapper;
using ReviewFilmes.Classes;
using ReviewFilmes.Dto;

namespace ReviewFilmes.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Filme, FilmeDto>();
        }
    }
}
