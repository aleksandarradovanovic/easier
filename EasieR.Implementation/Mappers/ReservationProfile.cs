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
            CreateMap<ReservationDto, Reservation>()
                 .ForMember(dest => dest.SeatTableReservation, opt => opt.MapFrom(src => src.SeatTableDtos.Select(x => new SeatTableReservation
                 {
                     SeatTableId = x.Id
                 })));
            CreateMap<Reservation, ReservationDto>()
            .ForMember(dest=>dest.ReservationTypeDto, opt =>opt.MapFrom(src=>src.ReservationType))
            .ForMember(dest => dest.PlaceName, opt => opt.MapFrom(src => src.ReservationType.Event.Place.Name))
            .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.ReservationType.Event.Name))
            .ForMember(dest => dest.EventStartTime, opt => opt.MapFrom(src => src.ReservationType.Event.StartTime))
            .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.ReservationType.Event.Description))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.CompleteAddress, opt => opt.MapFrom(src => src.ReservationType.Event.Place.Location.Country + ", " + src.ReservationType.Event.Place.Location.City + ", " + src.ReservationType.Event.Place.Location.StreetAndNumber))
            .ForMember(dest=> dest.SeatTableDtos, opt => opt.MapFrom(src=>src.SeatTableReservation.Select(x => new SeatTableDto
            {
                Number = x.SeatTable.Number
            })))
            .ForMember(dest=> dest.QRCodeContent, opt=>opt.MapFrom(src => System.Text.Encoding.UTF8.GetBytes(src.NameOn + ";" + src.ReservationType.Event.Name)));
            
        }
    }
}
