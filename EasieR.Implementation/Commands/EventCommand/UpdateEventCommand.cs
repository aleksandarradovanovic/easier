using EasieR.Application.Commands.EventCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Implementation.Validations.EventValidations;
using FluentValidation;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.EventCommand
{
    public class UpdateEventCommand : IUpdateEventCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly UpdateEventValidator _validator;
        public UpdateEventCommand(EasieRContext easieRContext, UpdateEventValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;
        }
        public int Id => 24;

        public string Name => RolesConstants.UpdateEvent;

        public void Execute(EventDto eventDto)
        {
            try
            {
                var eventForUpdate = _easieRContext.Event.FirstOrDefault(x => x.Id == eventDto.Id);
                if (eventForUpdate == null)
                {
                    throw new EntityNotFoundException(eventDto.Id, "Location");
                }
                _validator.ValidateAndThrow(eventDto);
                    eventForUpdate.Name = eventDto.Name;
                    eventForUpdate.Type = eventDto.Type;
                    eventForUpdate.Description = eventDto.Description;
                    eventForUpdate.StartTime = eventDto.StartTime;
                    eventForUpdate.EndTime = eventDto.EndTime;
                    eventForUpdate.PlaceId = eventDto.PlaceId;
                _easieRContext.Event.Update(eventForUpdate);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
