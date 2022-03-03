using AutoMapper;
using EasieR.Application.Commands.LocationCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.LocationValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Implementation.Commands.LocationCommand
{
    public class CreateLocationCommand : ICreateLocationCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly CreateLocationValidator _validator;
        private readonly IMapper _mapper;
        public CreateLocationCommand(EasieRContext easieRContext, CreateLocationValidator validator, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _validator = validator;
            _mapper = mapper;

        }
        public int Id =>11;

        public string Name => RolesConstants.CreateLocation;

        public void Execute(LocationDto locationDto)
        {
            try
            {
                _validator.ValidateAndThrow(locationDto);
                Location location = _mapper.Map<Location>(locationDto);
                _easieRContext.Location.Add(location);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
