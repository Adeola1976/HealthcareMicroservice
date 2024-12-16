﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.DTOs.Request
{
    public class HospitalPublishedDto
    {
        public string HospitalId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Event { get; set; }
    }
}
