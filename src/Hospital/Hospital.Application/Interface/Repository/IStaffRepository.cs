using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interface.Repository
{
    public interface IStaffRepository
    {
        void CreateStaff(Staff staff);
        Task<IEnumerable<Staff>> GetAllStaffs();
        void UpdateStaff(Staff staff);
        Task<Staff> GetStaffByStaffIdAsync(string StaffId, bool trackChanges);
    }
}
