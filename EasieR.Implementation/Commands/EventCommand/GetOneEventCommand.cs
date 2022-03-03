using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.EventQueries;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Nedelja7.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EasieR.Application.Constants;

namespace EasieR.Implementation.Commands.EventCommand
{
   public class GetOneEventCommand : IGetOneEventQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetOneEventCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;
        }
        public int Id => 22;

        public string Name => RolesConstants.GetOneEvent;

        public EventDto Execute(int id)
        {
            try
            {
                var eventItem = _easieRContext.Event.Include(x=>x.Reservations).Include(x => x.Place).ThenInclude(x=>x.Location).FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (eventItem == null)
                {
                    throw new EntityNotFoundException(id, "Event");
                }
                EventDto eventDto = _mapper.Map<EventDto>(eventItem);
                return eventDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
