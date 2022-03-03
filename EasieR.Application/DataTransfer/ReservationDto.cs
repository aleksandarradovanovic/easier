using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string NameOn { get; set; }
        public int UserId { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public int NumberOfGuests { get; set; } = 1;
        public decimal Price { get; set; }
        public int PlaceId { get; set; }
        public int EventId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceType { get; set; }
        public string CompleteAddress { get; set; }
        public string Username { get; set; }
        public string EventName { get; set; }
        public DateTime EventStartTime { get; set; }
        public string EventDescription { get; set; }
        public byte[] QRCodeContent { get; set; }
        public virtual ICollection<SeatTableDto> SeatTableDtos { get; set; }

    }
}
