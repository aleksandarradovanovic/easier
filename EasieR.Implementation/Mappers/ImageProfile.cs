using AutoMapper;
using EasieR.Application.DataTransfer;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Mappers
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Images, ImagesDto>();
            CreateMap<ImagesDto, Images>();
        }
    }
}
