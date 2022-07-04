using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
    public class ReservationTypeSeatTableProfile : Profile
    {
        public ReservationTypeSeatTableProfile()
        {
            CreateMap<ReservationTypeSeatsDto, SeatTableReservationType>();
            CreateMap<SeatTableReservationType, ReservationTypeSeatsDto>()
            .ForMember(dest => dest.SeatTableDto, opt => opt.MapFrom(src => src.SeatTable))

                ;
        }

    }
}
