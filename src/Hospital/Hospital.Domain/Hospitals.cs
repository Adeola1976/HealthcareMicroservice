using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain
{
    public class Hospitals : EntityBase
    {
        [Key]
        public string HospitalId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Staff>? Staff { get; set; }
        public Address? Address { get; set; }
        public Resources? Resources { get; set; }

    }
}
