using EasieR.Application.Constants;
using EasieR.Application.DataTransfer;
using EasieR.Application.Queries.Images;
using EasieR.Application.SearchData;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasieR.Implementation.Commands.ImageCommand
{
    public class GetImagesCommand : IGetImagesQuery
    {
        private readonly EasieRContext _easieRContext;
        public GetImagesCommand(EasieRContext easieRContext)
        {
            _easieRContext = easieRContext;
        }
        public int Id => 51;

        public string Name => RolesConstants.GetImages;

        public PagedResponse<ImagesDto> Execute(ImageSearch search)
        {
            try
            {
                var images = _easieRContext.Images.AsQueryable();
                if (search.PlaceId != 0)
                {
                    images = images.Where(x => x.PlaceId == search.PlaceId);
                }
                if (search.EventId != 0)
                {
                    images = images.Where(x => x.EventId == search.EventId);
                }
                var skipCount = search.PerPage * (search.Page - 1);
                var response = new PagedResponse<ImagesDto>
                {
                    CurrentPage = search.Page,
                    ItemsPerPage = search.PerPage,
                    TotalCount = images.Count(),
                    Items = images.Skip(skipCount).Take(search.PerPage).Select(x => new ImagesDto
                    {
                        Image = x.Image,
                        Size = (decimal)x.Size,
                        Name = x.Name
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
