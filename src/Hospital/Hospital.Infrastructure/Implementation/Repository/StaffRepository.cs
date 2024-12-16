using Hospital.Application.Interface.Repository;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Implementation.Repository
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateStaff(Staff staff) => Create(staff);

        public async Task<IEnumerable<Staff>> GetAllStaffs() => await FindAll(false)
       .OrderBy(e => e.CreatedAt)
       .ToListAsync();

        public void UpdateStaff(Staff staff) => Update(staff);
        public async Task<Staff> GetStaffByStaffIdAsync(string StaffId, bool trackChanges) =>
        await FindByCondition(x => x.StaffId.Equals(StaffId), trackChanges).FirstOrDefaultAsync();
    }
}
