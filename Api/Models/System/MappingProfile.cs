using System;
using Api.Models.Domain.AppUser;
using AutoMapper;

namespace Api.Models.System
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>();
        }
    }
}
