using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;
using User.Domain;

namespace User.Infrastructure.Implementation.Repository
{

    public class UserHospitalRepository : RepositoryBase<UserHospital>, IUserHospitalRepository
    {
        public UserHospitalRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateUserHospital(UserHospital hospital) => Create(hospital);

       public async Task<IEnumerable<UserHospital>> GetAllUserHospitals() => await FindAll(false)
      .OrderBy(e => e.CreatedAt)
      .ToListAsync();

        public void UpdateUserHospital(UserHospital hospital) => Update(hospital);
        public async Task<UserHospital> GetUserHospitalsByHospitalIdAsync(string HospitalId, bool trackChanges) =>
        await FindByCondition(x => x.HospitalId.Equals(HospitalId), trackChanges).FirstOrDefaultAsync();
    }
}
