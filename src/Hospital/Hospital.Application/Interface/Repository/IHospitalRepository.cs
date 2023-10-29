using Hospital.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interface.Repository
{
    public interface IHospitalRepository
    {
        void CreateHospital(Hospitals hospital);
        Task<IEnumerable<Hospitals>> GetAllHospitals();
        void UpdateHospital(Hospitals hospital);
        Task<Hospitals> GetHospitalsByHospitalIdAsync(string HospitalId, bool trackChanges);

    }
}
