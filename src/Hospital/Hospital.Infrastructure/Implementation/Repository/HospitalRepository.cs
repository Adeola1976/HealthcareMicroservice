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
    public class HospitalRepository : RepositoryBase<Hospitals>, IHospitalRepository
    {
        public HospitalRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateHospital(Hospitals hospital) => Create(hospital);

        public async Task<IEnumerable<Hospitals>> GetAllHospitals() => await FindAll(false)
       .OrderBy(e => e.CreatedAt)
       .ToListAsync();

        public void UpdateHospital(Hospitals hospital) => Update(hospital);
        public async Task<Hospitals> GetHospitalsByHospitalIdAsync(string HospitalId, bool trackChanges) =>
        await FindByCondition(x => x.HospitalId.Equals(HospitalId), trackChanges).FirstOrDefaultAsync();

    }
}
