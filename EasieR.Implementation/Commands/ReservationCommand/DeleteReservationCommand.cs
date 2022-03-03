using EasieR.Application.Commands.ReservationCommand;
using EasieR.Application.Constants;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ReservationCommand
{
    public class DeleteReservationCommand : IDeleteReservationCommand
    {
        private readonly EasieRContext _easieRContext;
        public DeleteReservationCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 30;

        public string Name => RolesConstants.DeleteReservation;

        public void Execute(int id)
        {
            try
            {
                var reservationToDelete = _easieRContext.Reservation.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (reservationToDelete == null)
                {
                    throw new EntityNotFoundException(id, "Reservation");
                }
                reservationToDelete.isDeleted = true;
                reservationToDelete.DeletedAt = DateTime.Now;
                reservationToDelete.isActive = false;
                _easieRContext.Reservation.Update(reservationToDelete);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
