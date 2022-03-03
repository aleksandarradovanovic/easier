using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
   public class SeatTableProfile : Profile
    {
        public SeatTableProfile()
        {
            CreateMap<SeatTableDto, SeatTable>();
            CreateMap<SeatTable, SeatTableDto>();

        }
    }
}
