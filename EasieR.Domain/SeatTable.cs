﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Domain
{
    public class SeatTable : Entity
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public bool isAvailable { get; set; }
        public int PlaceId { get; set; }
        public int? ReservationId { get; set; }
        public int? ReservationTypeId { get; set; }
        public ReservationType ReservationType { get; set; }
        public Place Place { get; set; }
        public ICollection<SeatTableReservationType> SeatTableReservationTypes { get; set; } = new HashSet<SeatTableReservationType>();
        public virtual ICollection<SeatTableReservation> SeatTableReservation { get; set; } = new HashSet<SeatTableReservation>();
    }
}
