﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.Application.DataTransfer
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int PlaceId { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public virtual ICollection<RolesDto> RolesDto { get; set; }
    }
}
