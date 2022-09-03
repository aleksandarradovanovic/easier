using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Mappers
{
   public class ReservationTypeProfile : Profile
    {
        public ReservationTypeProfile()
        {
            CreateMap<ReservationTypeDto, ReservationType>()
            .ForMember(dest => dest.SeatTableReservationTypes, opt => opt.MapFrom(src => src.AvailableSeatTablesDto));
            CreateMap<ReservationType, ReservationTypeDto>()
            .ForMember(dest => dest.AvailableSeatTablesDto, opt => opt.MapFrom(src => src.SeatTableReservationTypes));
            ;
        }
    }
}
