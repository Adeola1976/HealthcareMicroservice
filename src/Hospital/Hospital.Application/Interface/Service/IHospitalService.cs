using Hospital.Application.Utility;
using Hospital.Domain.DTOs.Request;
using Hospital.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interface.Service
{
    public interface IHospitalService
    {
        Task<GenericResponse<string>> CreateHospitalAsync(HospitalForCreationDto request);
        Task<GenericResponse<GetHospitalResponse>> GetHospitalAsync(string hospitalId);
        Task<GenericResponse<IEnumerable<GetHospitalResponse>>> GetAllHospitalsAsync();
        Task<GenericResponse<string>> UpdateHospitalAsync(UpdateHospitalDto request);
    }
}
