using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.LocationQueries;
using EasieR.DataAccess;
using Nedelja7.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.LocationCommand
{
    public class GetOneLocationCommand : IGetOneLocationQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetOneLocationCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;

        }
        public int Id => 12;

        public string Name => RolesConstants.GetOneLocation;

        public LocationDto Execute(int id)
        {
            try
            {
                var location = _easieRContext.Location.FirstOrDefault(x => !x.isDeleted && x.Id == id);
                if(location == null)
                {
                    throw new EntityNotFoundException(id, "Location");
                }
                LocationDto locationDto = _mapper.Map<LocationDto>(location);
                return locationDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
