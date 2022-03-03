using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
        }
    }
}
