using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.DTOs.Request
{
    public  class UserHospitalForCreationDto
    {
        public string HospitalId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
