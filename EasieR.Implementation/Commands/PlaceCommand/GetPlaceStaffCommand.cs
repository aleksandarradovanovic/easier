using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.PlaceQueries;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.PlaceCommand
{
    public class GetPlaceStaffCommand : IGetPlaceStaffQuery
    {
        private readonly EasieRContext _easieRContext;
        private readonly IMapper _mapper;
        public GetPlaceStaffCommand(EasieRContext easieRContext, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _mapper = mapper;

        }
        public int Id => 201;

        public string Name => RolesConstants.GetPlaceStaff;

        public PagedResponse<PlaceStaffDto> Execute(PlaceStaffSearch search)
        {
            try
            {
                var placeStaff = _easieRContext.PlaceStaff.AsQueryable();
                if (search.PlaceId != 0)
                {
                    placeStaff = placeStaff.Where(x => x.PlaceId == search.PlaceId);
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<PlaceStaffDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = placeStaff.Count(),
                    Items = placeStaff.Skip(skipCount).Take(search.PerPage).Select(x => new PlaceStaffDto
                    {
                        Position = x.Position,
                        UserDto = _mapper.Map<UserDto>(x.User)
                    })
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
