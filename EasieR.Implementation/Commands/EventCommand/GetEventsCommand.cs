using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.EventQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.EventCommand
{
    public class GetEventsCommand : IGetEventsQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;

        public GetEventsCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;

        }
        public int Id => 23;

        public string Name => RolesConstants.SearchEvent;

        public PagedResponse<EventDto> Execute(EventSearch search)
        {
            try
            {
                var eventItem = _easieRContext.Event.Include(x => x.Reservations).Include(x => x.Place).ThenInclude(x => x.Location).AsQueryable().Where(x => !x.isDeleted);
                if (search.Name != null)
                {
                    search.Name = search.Name.ToLower();
                    eventItem = eventItem.Where(x => x.Name.ToLower().Contains(search.Name));
                }
                if (search.Type != null)
                {
                    search.Type = search.Type.ToLower();
                    eventItem = eventItem.Where(x => x.Type.ToLower().Contains(search.Type));
                }
                if (search.Description != null)
                {
                    search.Description = search.Description.ToLower();
                    eventItem = eventItem.Where(x => x.Description.ToLower().Contains(search.Description));
                }
                if (search.StartTime != null)
                {
                    eventItem = eventItem.Where(x => x.StartTime >= search.StartTime);
                }
                if (search.EndTime != null)
                {
                    eventItem = eventItem.Where(x => x.EndTime <= search.EndTime);
                }
                if (search.PlaceName != null)
                {
                    search.PlaceName = search.PlaceName.ToLower();
                    eventItem = eventItem.Where(x => x.Place.Name.ToLower().Contains(search.PlaceName));
                }
                if (search.PlaceType != null)
                {
                    search.PlaceType = search.PlaceType.ToLower();
                    eventItem = eventItem.Where(x => x.Place.Type.ToLower().Contains(search.PlaceType));
                }
                if (search.Country != null)
                {
                    search.Country = search.Country.ToLower();
                    eventItem = eventItem.Where(x => x.Place.Location.Country.ToLower().Contains(search.Country));
                }
                if (search.City != null)
                {
                    search.City = search.City.ToLower();
                    eventItem = eventItem.Where(x => x.Place.Location.City.ToLower().Contains(search.City));
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<EventDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = eventItem.Count(),
                    Items = eventItem.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<EventDto>(x)
                    )
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
