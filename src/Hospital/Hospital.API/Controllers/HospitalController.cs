using Hospital.Application.Interface.Service;
using Hospital.Application.Utility;
using Hospital.Domain.DTOs.Request;
using Hospital.Domain.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public HospitalController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost("createhospital")]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateHospital(HospitalForCreationDto request)
        {
            var response = await _serviceManager.HospitalService.CreateHospitalAsync(request);
            return Ok(response);
        }

        [HttpGet("gethospital")]
        [ProducesResponseType(typeof(GenericResponse<GetHospitalResponse>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> GetHospital([FromQuery] string hospitalId)
        {
            var response = await _serviceManager.HospitalService.GetHospitalAsync(hospitalId);
            return Ok(response);
        }

        [HttpGet("getallhospital")]
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<GetHospitalResponse>>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> GetAllHospitals()
        {
            var response = await _serviceManager.HospitalService.GetAllHospitalsAsync();
            return Ok(response);
        }

        [HttpGet("updatehospital")]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateHospital(UpdateHospitalDto request)
        {
            var response = await _serviceManager.HospitalService.UpdateHospitalAsync(request);
            return Ok(response);
        }
    }
}
