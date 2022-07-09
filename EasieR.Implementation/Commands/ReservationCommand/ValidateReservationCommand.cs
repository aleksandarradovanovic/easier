using EasieR.Application.Commands.ReservationCommand;
using EasieR.Application.Constants;
using EasieR.Application.Exceptions;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using EasieR.Implementation.Crypt;
using Microsoft.EntityFrameworkCore;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ReservationCommand
{
    public class ValidateReservationCommand : IValidateReservationCommand
    {
        private readonly EasieRContext _easieRContext;

        public ValidateReservationCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 30;

        public string Name => RolesConstants.CreateReservation;

        public void Execute(ReservationValidationRo request)
        {
            try
            {
                var reservationsForUpdate = _easieRContext.Reservation.Include(x => x.ReservationSequence).Include(x=>x.ReservationType).ThenInclude(x=>x.Event).Include(x=>x.User).FirstOrDefault(x => !x.isDeleted && x.Id == request.Id);
                if (reservationsForUpdate == null)
                {
                    throw new EntityNotFoundException(request.Id, "Reservation");
                }
                if(request.ReservationQRCodeContent != null)
                {
                    string CriptData = CryptUtil.DecryptToStringNew(request.ReservationQRCodeContent, reservationsForUpdate.ReservationSequence.PrivateKey);
                    string[] decryptedStringData = CriptData.Split(";");
                    if (Int32.Parse(decryptedStringData[0]) == reservationsForUpdate.Id
                        && Int32.Parse(decryptedStringData[1]) == reservationsForUpdate.ReservationType.Event.Id
                        && Int32.Parse(decryptedStringData[2]) == reservationsForUpdate.User.Id
                        && decryptedStringData[3] == reservationsForUpdate.NameOn
                        && reservationsForUpdate.Status != "VALIDATE"
                        )
                    {
                        reservationsForUpdate.Status = "VALIDATE";
                        _easieRContext.Reservation.Update(reservationsForUpdate);
                        _easieRContext.SaveChanges();
                    } else {
                        throw new GeneralErrorException("Reservation not valid!");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
