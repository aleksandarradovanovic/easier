using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using EasieR.Application.DataTransfer;
using EasieR.Domain;

namespace EasieR.Implementation.Mappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Roles, RolesDto>();
            CreateMap<RolesDto, Roles>();
        }
    }
}
