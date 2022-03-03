using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Mappers
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.CompleteAddress, opt => opt.MapFrom(src => src.Place.Location.Country + ", " + src.Place.Location.City + ", " + src.Place.Location.StreetAndNumber))
            .ForMember(dest=> dest.SeatTableDtos, opt => opt.MapFrom(src=>src.SeatTableReservation.Select(x => new SeatTableDto
            {
                Number = x.SeatTable.Number
            })))
            .ForMember(dest=> dest.QRCodeContent, opt=>opt.MapFrom(src => System.Text.Encoding.UTF8.GetBytes(src.NameOn + ";" + src.Event.Name)));
            
        }
    }
}
