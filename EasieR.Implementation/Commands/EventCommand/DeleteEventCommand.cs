using EasieR.Application.Commands.EventCommand;
using EasieR.Application.Constants;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.EventCommand
{
    public class DeleteEventCommand : IDeleteEventCommand
    {
        private readonly EasieRContext _easieRContext;
        public DeleteEventCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 25;

        public string Name => RolesConstants.DeleteEvent;

        public void Execute(int id)
        {
            try
            {
                var eventToDelete = _easieRContext.Event.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (eventToDelete == null)
                {
                    throw new EntityNotFoundException(id, "Event");
                }
                eventToDelete.isDeleted = true;
                eventToDelete.DeletedAt = DateTime.Now;
                eventToDelete.isActive = false;
                _easieRContext.Event.Update(eventToDelete);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
