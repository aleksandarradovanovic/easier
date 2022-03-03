using AutoMapper;
using EasieR.Application.Commands.EventCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.EventValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.EventCommand
{
    public class CreateEventCommand : ICreateEventCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly CreateEventValidator _validator;
        private readonly IMapper _mapper;

        public CreateEventCommand(EasieRContext easieRContext, CreateEventValidator validator, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _validator = validator;
            _mapper = mapper;

        }
        public int Id => 21;

        public string Name => RolesConstants.CreateEvent;

        public void Execute(EventDto eventDto)
        {
            try
            {
                _validator.ValidateAndThrow(eventDto);
                Event eventData = _mapper.Map<Event>(eventDto);
                _easieRContext.Event.Add(eventData);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
