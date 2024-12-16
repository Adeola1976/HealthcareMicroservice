using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain
{
    public class Role : EntityBase
    {
        [Key]
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Staff? Staff { get; set; }
    }
}
