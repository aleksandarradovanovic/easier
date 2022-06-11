using AutoMapper;
using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.SeatTable;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using EasieR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.SeatTableCommand
{
    public class GetSeatTablesCommand : IGetSeatTablesQuery
    {
        private readonly EasieRContext _easieRContext;
        public GetSeatTablesCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }

        public int Id => 41;

        public string Name => RolesConstants.GetImages;

        public PagedResponse<SeatTableDto> Execute(SeatTableSearch search)
        {
            try
            {
                var seatTables = _easieRContext.SeatTable.AsQueryable();
                if (search.PlaceId !=0)
                {
                    seatTables = seatTables.Where(x => x.PlaceId == search.PlaceId);
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<SeatTableDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = seatTables.Count(),
                    Items = seatTables.Skip(skipCount).Take(search.PerPage).Select(x => new SeatTableDto
                    {
                        Type = x.Type,
                        Number = x.Number
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
