using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PlaceId {get; set; }
        public string PlaceName { get; set; }
        public PlaceDto PlaceDto { get; set; }
        public virtual ICollection<ReservationDto> ReservationDtos { get; set; }
        public virtual ICollection<ImagesDto> ImagesDtos { get; set; }
    }
}
