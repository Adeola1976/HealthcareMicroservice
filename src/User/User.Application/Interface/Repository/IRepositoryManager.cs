using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Interface.Repository
{
    public  interface IRepositoryManager
    {
        IUserHospitalRepository UserHospital { get; }
        Task SaveAsync();
    }
}
