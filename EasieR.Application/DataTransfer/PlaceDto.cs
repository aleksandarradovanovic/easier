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
        public string StartWorkingTime { get; set; }
        public string EndWorkingTime { get; set; }
        public LocationDto LocationDto { get; set; }
        public int UserId { get; set; }
        public int EventsCount { get; set; }
        public int SeatTablesCount { get; set; }
        public int StaffCount { get; set; }
        public int ImagesCount { get; set; }
        public virtual ICollection<EventDto> EventsDto { get; set; }
        public virtual ICollection<SeatTableDto> SeatTableDtos { get; set; }
        public virtual ICollection<UserDto> StaffDtos { get; set; }
        public virtual ICollection<ImagesDto> ImagesDtos { get; set; }

    }
}
