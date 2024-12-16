using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Interface.Service
{
    public interface IServiceManager
    {
        IUserHospitalService UserHospitalService { get; }
    }
}
