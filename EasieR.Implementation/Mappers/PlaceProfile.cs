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
                 .ForMember(dest => dest.ImagesDtos, opt => opt.MapFrom(src => src.Images))
                 .ForMember(dest => dest.ImagesCount, opt => opt.MapFrom(src => src.Images.Count))
                 .ForMember(dest => dest.SeatTableDtos, opt => opt.MapFrom(src => src.SeatTables))
                  .ForMember(dest => dest.ImagesCount, opt => opt.MapFrom(src => src.SeatTables.Count))

                 .ForMember(dest => dest.EventsDto, opt => opt.MapFrom(src => src.Events))
                  .ForMember(dest => dest.EventsCount, opt => opt.MapFrom(src => src.Events.Count));
            CreateMap<PlaceDto, Place>()
                .ForMember(dest => dest.Location,
                opt => opt.MapFrom(src => src.LocationDto)
                )
                 .ForMember(dest => dest.SeatTables, opt => opt.MapFrom(x => x.SeatTableDtos))
                 .ForMember(dest => dest.Images, opt => opt.MapFrom(x => x.ImagesDtos))
                 .ForMember(dest => dest.Staff, opt => opt.MapFrom(x => new List<PlaceStaff> { new PlaceStaff { 
                    Position = "Owner",
                    UserId = x.UserId
                 }}));


        }
    }
}
