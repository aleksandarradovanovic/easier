using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class ImagesDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public PlaceDto PlaceDto { get; set; }
        public EventDto EventDto { get; set; }

    }
}
