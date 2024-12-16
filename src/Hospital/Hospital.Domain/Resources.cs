using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain
{
    public class Resources : EntityBase
    {
        [Key]
        public string ResourcesId { get; set; }
        public string HospitalId { get; set; }
        public Hospitals Hospital { get; set; }
    }
}
