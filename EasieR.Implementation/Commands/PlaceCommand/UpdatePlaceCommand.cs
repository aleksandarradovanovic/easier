using EasieR.Application.Commands.PlaceCommand;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using EasieR.Domain;
using EasieR.Implementation.Validations.PlaceValidations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.PlaceCommand
{
    public class UpdatePlaceCommand : IUpdatePlaceCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly UpdatePlaceValidator _validator;

        public UpdatePlaceCommand(EasieRContext easieRContext, UpdatePlaceValidator validator)
        {
            _easieRContext = easieRContext;
            _validator = validator;
        }
        public int Id => 19;

        public string Name => RolesConstants.UpdatePlace;

        public void Execute(PlaceDto placeDto)
        {
            try
            {
                var placeForUpdate = _easieRContext.Place.Include(x =>x.Location).FirstOrDefault(x => x.Id == placeDto.Id);
                if (placeForUpdate == null)
                {
                    throw new EntityNotFoundException(placeDto.Id, "Place");
                }
                _validator.ValidateAndThrow(placeDto);
                if (placeForUpdate.Name != null)
                {
                    placeForUpdate.Name = placeDto.Name;
                }
                if (placeForUpdate.Type != null)
                {
                    placeForUpdate.Type = placeDto.Type;
                }
                if (placeForUpdate.Description != null)
                {
                    placeForUpdate.Description = placeDto.Description;
                }
                if (placeForUpdate.StartWorkingTime != null)
                {
                    placeForUpdate.StartWorkingTime = placeDto.StartWorkingTime;
                }
                if (placeForUpdate.EndWorkingTime != null)
                {
                    placeForUpdate.EndWorkingTime = placeDto.EndWorkingTime;
                }
                if (placeForUpdate.Location != null)
                {
                    placeForUpdate.Location.Country = placeDto.LocationDto.Country;
                    placeForUpdate.Location.City = placeDto.LocationDto.City;
                    placeForUpdate.Location.StreetAndNumber = placeDto.LocationDto.StreetAndNumber;
                    placeForUpdate.Location.Latitude = placeDto.LocationDto.Latitude;
                    placeForUpdate.Location.Longitude = placeDto.LocationDto.Longitude;
                }
                if (placeDto.SeatTableDtos != null && placeDto.SeatTableDtos.Count > 0)
                {
                    var seatTablesToRemove = _easieRContext.SeatTable.AsQueryable().Where(x => x.PlaceId == placeDto.Id);
                    if (seatTablesToRemove != null)
                    {
                        foreach (var item in seatTablesToRemove)
                        {
                            _easieRContext.SeatTable.Remove(item);
                        }
                    }
                    placeForUpdate.SeatTables = placeDto.SeatTableDtos.Select(x => new SeatTable
                    {
                        Type = x.Type,
                        Number = x.Number,
                        isAvailable = x.isAvailable || true
                    }).ToList();
                }
                if (placeDto.ImagesDtos != null && placeDto.ImagesDtos.Count > 0)
                {
                    var imagesToRemove = _easieRContext.Images.AsQueryable().Where(x => x.PlaceId == placeDto.Id);
                    if(imagesToRemove != null)
                    {
                        foreach (var item in imagesToRemove)
                        {
                            _easieRContext.Images.Remove(item);
                        }
                    }
                   
                   placeForUpdate.Images = placeDto.ImagesDtos.Select(x => new Images
                    {
                        Image = x.Image,
                        Name = x.Name,
                        Size = x.Size
                    }).ToList();
                }
                _easieRContext.Place.Update(placeForUpdate);
                _easieRContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
