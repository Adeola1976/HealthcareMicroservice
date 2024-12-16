using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain
{
    public class Staff : EntityBase
    {
        [Key]
        public string StaffId { get; set; }
        public string RoleId { get; set; }
        public string HospitalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Hospitals Hospital { get; set; }
        public Role Role { get; set; }

    }
}
