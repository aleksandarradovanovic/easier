using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.PlaceQueries;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.PlaceCommand
{
    public class GetOnePlaceCommand : IGetOnePlaceQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;

        public GetOnePlaceCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;

        }
        public int Id => 17;

        public string Name => RolesConstants.GetOnePlace;

        public PlaceDto Execute(int id)
        {
            try
            {
                var place = _easieRContext.Place.Include(x => x.Location).Include(x=>x.Events).Include(x => x.SeatTables)
                    .FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if (place == null)
                {
                    throw new EntityNotFoundException(id, "Place");

                }
                PlaceDto placeDto = _mapper.Map<PlaceDto>(place);
                return placeDto;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
