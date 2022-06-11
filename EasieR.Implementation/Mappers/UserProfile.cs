using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Mappers
{
   public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles,
                opt => opt.MapFrom(src=>src.UserRoles.Select(x => x.Roles.Id).ToArray())
                )
             .ForMember(dest => dest.RolesDto,
                opt => opt.MapFrom(src => src.UserRoles.Select(x => x.Roles).ToArray())
                );
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles.Select(x=> new UserRoles { RoleId = x})));
        }
    }
}
