using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDto, Event>()
                 .ForMember(dest => dest.ReservationTypes, opt => opt.MapFrom(src => src.ReservationTypeDtos))
                .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.ImagesDtos));

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.ImagesDtos, opt => opt.MapFrom(src => src.EventImages))
                .ForMember(dest => dest.ReservationTypeDtos, opt => opt.MapFrom(src => src.ReservationTypes))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.EventImages.FirstOrDefault().Image))
                .ForMember(dest => dest.PlaceDto, opt => opt.Ignore());
        }
    }
}
