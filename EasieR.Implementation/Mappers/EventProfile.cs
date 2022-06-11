using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDto, Event>()
                .ForMember(dest => dest.EventImages, opt => opt.MapFrom(src => src.ImagesDtos));
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.ImagesDtos, opt => opt.MapFrom(src => src.EventImages))
                .ForMember(dest => dest.PlaceDto, opt => opt.Ignore());
        }
    }
}
