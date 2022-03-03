using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.PlaceQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.PlaceCommand
{
    public class GetPlacesCommand : IGetPlacesQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetPlacesCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;
        }
        public int Id =>18;

        public string Name => RolesConstants.SearchPlace;

        public PagedResponse<PlaceDto> Execute(PlaceSearch search)
        {
            try
            {
                var places = _easieRContext.Place.Include(x => x.Location).Include(x => x.Events).AsQueryable().Where(x => !x.isDeleted);
                if (search.Name != null)
                {
                    search.Name = search.Name.ToLower();
                    places = places.Where(x => x.Name.ToLower().Contains(search.Name));
                }
                if (search.Type != null)
                {
                    search.Type = search.Type.ToLower();
                    places = places.Where(x => x.Type.ToLower().Contains(search.Type));
                }
                if (search.Description != null)
                {
                    search.Description = search.Description.ToLower();
                    places = places.Where(x => x.Description.ToLower().Contains(search.Description));
                }
                if (search.EventName != null)
                {
                    search.EventName = search.EventName.ToLower();
                    places = places.Where(x => x.Events.Any(e => e.Name.Contains(search.EventName)));
                }
                if (search.EventType != null)
                {
                    search.EventType = search.EventType.ToLower();
                    places = places.Where(x => x.Events.Any(e => e.Type.Contains(search.EventType)));
                }
                if (search.Country != null)
                {
                    search.Country = search.Country.ToLower();
                    places = places.Where(x => x.Location.Country.ToLower().Contains(search.Country));
                }
                if (search.City != null)
                {
                    search.City = search.City.ToLower();
                    places = places.Where(x => x.Location.City.ToLower().Contains(search.City));
                }
                if (search.StreetAndNumber != null)
                {
                    search.StreetAndNumber = search.StreetAndNumber.ToLower();
                    places = places.Where(x => x.Location.StreetAndNumber.ToLower().Contains(search.StreetAndNumber));
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<PlaceDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = places.Count(),
                    Items = places.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<PlaceDto>(x))
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
