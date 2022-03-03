using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
   public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartWorkingTime { get; set; }
        public DateTime EndWorkingTime { get; set; }
        public LocationDto LocationDto { get; set; }
        public virtual ICollection<EventDto> EventsDto { get; set; }
        public virtual ICollection<SeatTableDto> SeatTableDtos { get; set; }
        public virtual ICollection<UserDto> StaffDtos { get; set; }
        public virtual ICollection<ImagesDto> ImagesDtos { get; set; }

    }
}
