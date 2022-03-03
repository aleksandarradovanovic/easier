using EasieR.Application.Commands.LocationCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Implementation.Validations.LocationValidations;
using FluentValidation;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.LocationCommand
{
    public class UpdateLocationCommand : IUpdateLocationCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly CreateLocationValidator _validator;
        public UpdateLocationCommand(EasieRContext easieRContext, CreateLocationValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;
        }
        public int Id => 14;

        public string Name => RolesConstants.UpdateLocation;

        public void Execute(LocationDto locationDto)
        {
            try
            {
                var locationForUpdate = _easieRContext.Location.FirstOrDefault(x => x.Id == locationDto.Id);
                if (locationForUpdate == null)
                {
                    throw new EntityNotFoundException(locationDto.Id, "Location");
                }
                _validator.ValidateAndThrow(locationDto);

                locationForUpdate.Country = locationDto.Country;
                locationForUpdate.City = locationDto.City;
                locationForUpdate.StreetAndNumber = locationDto.StreetAndNumber;
                locationForUpdate.Latitude = locationDto.Latitude;
                locationForUpdate.Longitude = locationDto.Longitude;
                _easieRContext.Location.Update(locationForUpdate);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
