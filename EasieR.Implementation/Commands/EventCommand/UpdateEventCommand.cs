using EasieR.Application.Commands.EventCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
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
                if (eventDto.ImagesDtos != null && eventDto.ImagesDtos.Count > 0)
                {
                    var imagesToRemove = _easieRContext.Images.AsQueryable().Where(x => x.EventId == eventDto.Id);
                    if (imagesToRemove != null)
                    {
                        foreach (var item in imagesToRemove)
                        {
                            _easieRContext.Images.Remove(item);
                        }
                    }

                    eventForUpdate.EventImages = eventDto.ImagesDtos.Select(x => new Images
                    {
                        Image = x.Image,
                        Name = x.Name,
                        Size = x.Size
                    }).ToList();
                }
                if (eventDto.ImagesDtos != null && eventDto.ImagesDtos.Count > 0)
                    {
                    eventForUpdate.EventImages = eventDto.ImagesDtos.Select(x => new Images
                    {
                        Name = x.Name,
                        Image = x.Image,
                        Size = x.Size
                    }).ToArray();
                    }
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
