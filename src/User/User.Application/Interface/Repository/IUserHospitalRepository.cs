using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;

namespace User.Application.Interface.Repository
{
    public  interface IUserHospitalRepository
    {
        void CreateUserHospital(UserHospital hospital);
        Task<IEnumerable<UserHospital>> GetAllUserHospitals();
        void UpdateUserHospital(UserHospital hospital);
        Task<UserHospital> GetUserHospitalsByHospitalIdAsync(string HospitalId, bool trackChanges);
    }
}
