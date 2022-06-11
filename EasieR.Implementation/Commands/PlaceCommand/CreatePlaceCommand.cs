using AutoMapper;
using EasieR.Application;
using EasieR.Application.Commands.PlaceCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.PlaceValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.PlaceCommand
{
    public class CreatePlaceCommand : ICreatePlaceCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        private readonly CreatePlaceValidator _validator;
        private readonly IApplicationActor _actor;


        public CreatePlaceCommand(EasieRContext easieRContext, CreatePlaceValidator validator, IMapper mapper, IApplicationActor actor)
        {
            _easieRContext = easieRContext;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }
        public int Id => 16;

        public string Name => RolesConstants.CreatePlace;

        public void Execute(PlaceDto placeDto)
        {
            placeDto.UserId = _actor.Id;
            try
            {
                _validator.ValidateAndThrow(placeDto);
                Place place = _mapper.Map<Place>(placeDto);
                _easieRContext.Place.Add(place);
                _easieRContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
