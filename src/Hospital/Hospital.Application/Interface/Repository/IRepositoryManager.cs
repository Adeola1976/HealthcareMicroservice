using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interface.Repository
{
    public interface IRepositoryManager
    {
        IHospitalRepository Hospital { get; }
        IStaffRepository Staff { get; }
        Task SaveAsync();
    }
}
