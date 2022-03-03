using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
   public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<Place, PlaceDto>()
                .ForMember(dest => dest.LocationDto,
                opt => opt.MapFrom(src => src.Location)
                )
                 .ForMember(dest=> dest.EventsDto, opt => opt.MapFrom(src=>src.Events));
            CreateMap<PlaceDto, Place>()
                .ForMember(dest => dest.Location,
                opt => opt.MapFrom(src => src.LocationDto)
                )
                 .ForMember(dest => dest.SeatTables, opt => opt.MapFrom(x => x.SeatTableDtos));



        }
    }
}
