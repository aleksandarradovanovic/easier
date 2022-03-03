using EasieR.Application.Commands.PlaceCommand;
using EasieR.Application.Constants;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.PlaceCommand
{
    public class DeletePlaceCommand : IDeletePlaceCommand
    {
        private readonly EasieRContext _easieRContext;
        public DeletePlaceCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 20;

        public string Name => RolesConstants.DeletePlace;

        public void Execute(int id)
        {
            try
            {
                var placeToDelete = _easieRContext.Place.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (placeToDelete == null)
                {
                    throw new EntityNotFoundException(id, "Place");
                }
                placeToDelete.isDeleted = true;
                placeToDelete.DeletedAt = DateTime.Now;
                placeToDelete.isActive = false;
                _easieRContext.Place.Update(placeToDelete);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
