using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EasieR.Implementation.Mappers
{
   public class UserProfile : Profile
    {
        public UserProfile()
        {
            var md5 = new MD5CryptoServiceProvider();
            CreateMap<User, UserDto>()
             .ForMember(dest => dest.RolesDto,
                opt => opt.MapFrom(src => src.Actor.ActorRoles.Select(x => x.Roles).ToArray())
                );
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.PlaceStaffs, opt => {
                    opt.PreCondition(p => p.PlaceId != 0 && p.Position != null);
                    opt.MapFrom(src => new List<PlaceStaff> { new PlaceStaff {
                    Position = src.Position,
                    PlaceId = src.PlaceId
                 }});
                })
              //  .ForMember(dest=>dest.Password, opt => opt.MapFrom(src=> md5.ComputeHash(Encoding.ASCII.GetBytes(src.Password))))
                ;
        }
    }
}
