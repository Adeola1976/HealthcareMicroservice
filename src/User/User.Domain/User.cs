using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain
{
    public class User : EntityBase
    {
        public string UserId { get; set; }
        public string? HospitalId { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Address address { get; set; }
    }
}
