using Microsoft.AspNetCore.Mvc;
using System.Net;
using User.Application.Interface.Service;
using User.Application.Utility;
using User.Domain.DTOs.Request;
using User.Domain.DTOs.Response;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHospitalController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UserHospitalController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost("createhospital")]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateHospital(UserHospitalForCreationDto request)
        {
            var response = await _serviceManager.UserHospitalService.CreateUserHospitalAsync(request);
            return Ok(response);
        }

        [HttpGet("gethospital")]
        [ProducesResponseType(typeof(GenericResponse<GetUserHospitalResponse>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> GetHospital([FromQuery] string hospitalId)
        {
            var response = await _serviceManager.UserHospitalService.GetUserHospitalAsync(hospitalId);
            return Ok(response);
        }

        [HttpGet("getallhospital")]
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<GetUserHospitalResponse>>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> GetAllHospitals()
        {
            var response = await _serviceManager.UserHospitalService.GetAllUserHospitalsAsync();
            return Ok(response);
        }

    }
}
