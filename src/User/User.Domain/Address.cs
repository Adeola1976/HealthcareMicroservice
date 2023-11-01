using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain
{
    public  class Address : EntityBase
    {
        public string? AddressId { get; set; }
        public string? UserId { get; set; }
        public string? HouseNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public User User { get; set; }
    }
}
