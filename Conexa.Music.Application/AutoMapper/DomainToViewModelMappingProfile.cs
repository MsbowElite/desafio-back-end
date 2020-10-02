using AutoMapper;
using Conexa.Music.Application.ViewModels;
using Conexa.Music.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Item, SongViewModel>();
        }
    }
}
