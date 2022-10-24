using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Details;
using Application.Users;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, UserInfoDto>()
                .ForMember(d => d.Info, o => o.MapFrom(src => src.Information));
            CreateMap<InfoDto, Information>();
            CreateMap<Information, InfoDto>();
            CreateMap<Information, EditDto>().ReverseMap();
        }

    }
}