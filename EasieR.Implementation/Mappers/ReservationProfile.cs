using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasieR.Implementation.Crypt;
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
                 })))
                 .ForMember(dest=>dest.ReservationSequence, opt => opt.MapFrom(src=> new ReservationSequence { PrivateKey = Enumerable.Range(0, 100).Select(n => n * 2).ToString() + DateTime.Now.ToString()
                 }));
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
            .ForMember(dest=> dest.QRCodeContent, opt=>opt.MapFrom(src => CryptUtil.EncryptStringNew(
                  src.Id + ";"
                + src.ReservationType.Event.Id + ";"
                + src.User.Id + ";"
                + src.NameOn
                , src.ReservationSequence.PrivateKey)));
            
        }
    }
}
