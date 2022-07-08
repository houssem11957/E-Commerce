using AutoMapper;
using MyAxiaMarket.Models;
using MyAxiaMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.Mapper
{
    public class MapperProfiles : Profile
    {

        public MapperProfiles()
            {

            CreateMap<Personne, PersonneViewModel>()
                .ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.AdresseP))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.NomP))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.PrenomP))
            
                .ReverseMap();

            CreateMap<Personne, PersonneViewModelForRead>()

                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.NomP))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.PrenomP))
                .ForMember(m => m.FullName, i => i.MapFrom(src => src.PrenomP + " " + src.NomP))
                 .ReverseMap();
        }
    }
}
