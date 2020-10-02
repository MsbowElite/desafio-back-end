using AutoMapper;
using Conexa.Music.Application.Songs;
using Conexa.Music.Domain.Models;

namespace Conexa.Music.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Item, SongDto>();
        }
    }
}
