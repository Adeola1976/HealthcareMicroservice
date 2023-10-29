using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain
{
    public class Address : EntityBase
    {
        [Key]
        public string AddressId { get; set; }
        public string HospitalId { get; set; }
        public int? Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Hospitals Hospital { get; set; }
    }
}
