using EasieR.Application.Commands.LocationCommand;
using EasieR.Application.Constants;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.LocationCommand
{
    public class DeleteLocationCommand : IDeleteLocationCommand
    {
        private readonly EasieRContext _easieRContext;
        public DeleteLocationCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id =>15;

        public string Name => RolesConstants.DeleteLocation;

        public void Execute(int id)
        {
            try
            {
                var locationToDelete = _easieRContext.Location.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (locationToDelete == null)
                {
                    throw new EntityNotFoundException(id, "Location");
                }
                locationToDelete.isDeleted = true;
                locationToDelete.DeletedAt = DateTime.Now;
                locationToDelete.isActive = false;
                _easieRContext.Location.Update(locationToDelete);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
