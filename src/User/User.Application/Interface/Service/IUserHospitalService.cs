using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Utility;
using User.Domain.DTOs.Request;
using User.Domain.DTOs.Response;

namespace User.Application.Interface.Service
{
    public  interface IUserHospitalService
    {
        Task<GenericResponse<string>> CreateUserHospitalAsync(UserHospitalForCreationDto request);
        Task<GenericResponse<GetUserHospitalResponse>> GetUserHospitalAsync(string hospitalId);
        Task<GenericResponse<IEnumerable<GetUserHospitalResponse>>> GetAllUserHospitalsAsync();

    }
}
