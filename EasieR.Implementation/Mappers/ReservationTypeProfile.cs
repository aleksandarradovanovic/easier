using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
   public class ReservationTypeProfile : Profile
    {
        public ReservationTypeProfile()
        {
            CreateMap<ReservationTypeDto, ReservationType>();

            CreateMap<ReservationType, ReservationTypeDto>();
        }
    }
}
