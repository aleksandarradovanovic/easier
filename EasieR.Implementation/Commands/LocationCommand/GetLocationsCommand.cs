using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.LocationQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.LocationCommand
{
    public class GetLocationsCommand : IGetLocationQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;

        public GetLocationsCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;

        }
        public int Id => 12;

        public string Name => RolesConstants.SearchLocation;

        public PagedResponse<LocationDto> Execute(LocationSearch search)
        {
            try
            {
                var locations = _easieRContext.Location.AsQueryable().Where(x => !x.isDeleted);
                if(search.Country != null)
                {
                    search.Country = search.Country.ToLower();
                    locations = locations.Where(x => x.Country.ToLower().Contains(search.Country));
                }
                if (search.City != null)
                {
                    search.City = search.City.ToLower();
                    locations = locations.Where(x => x.City.ToLower().Contains(search.City));
                }
                if (search.StreetAndNumber != null)
                {
                    search.StreetAndNumber = search.StreetAndNumber.ToLower();
                    locations = locations.Where(x => x.StreetAndNumber.ToLower().Contains(search.StreetAndNumber));
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<LocationDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = locations.Count(),
                    Items = locations.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<LocationDto>(x))
                };
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
