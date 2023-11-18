using AutoMapper;
using Hospital.Application.Interface.Repository;
using Hospital.Application.Interface.Service;
using Hospital.Application.Utility;
using Hospital.Domain.DTOs.Request;
using Hospital.Domain.DTOs.Response;
using Hospital.Domain;
using Hospital.Infrastructure.Implementation.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Implementation.Service
{
    public class HospitalService : IHospitalService
    {

        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<HospitalService> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;

        public HospitalService(IRepositoryManager repositoryManager, IMapper mapper, ILogger<HospitalService> logger, IHttpService httpService, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<GenericResponse<string>> CreateHospitalAsync(HospitalForCreationDto request)
        {
            _logger.LogInformation($"Inside the CreateHospitalAync");
            _logger.LogInformation($"payload to create a new hospital is {request}");
          

            try
            {
                var hospitalEntity = _mapper.Map<Hospitals>(request);
                var userHospitalRequest = _mapper.Map<UserHospitalForCreationDto>(request);
                hospitalEntity.HospitalId = Guid.NewGuid().ToString();
                userHospitalRequest.HospitalId = hospitalEntity.HospitalId;
                _repositoryManager.Hospital.CreateHospital(hospitalEntity);  
                var url = $"{_configuration.GetSection("ExternalApis")["User"]}/api/UserHospital/createhospital";
                _logger.LogInformation($"The url to reach out to user endpoint is {url}, say yes to caps appsettings");
                var apirequest = new PostRequest<UserHospitalForCreationDto>
                {
                    Url = url,
                    Data = userHospitalRequest
                };
                var response = await _httpService.SendPostRequest<ApiResponse, UserHospitalForCreationDto>(apirequest);
                _logger.LogInformation($"The response from the api is {response}");
                await _repositoryManager.SaveAsync();
                _logger.LogInformation($"request saved in database");
                return new GenericResponse<string>()
                {
                    IsSuccessful = true,
                    ResponseCode = "00",
                    ResponseMessage = "Hospital Created successful"
                };
            }
             
            catch (Exception ex)
            {
                _logger.LogError($"Error occur while creating a new hospital. Error message : {ex.Message}");
                return new GenericResponse<string>()
                {
                    IsSuccessful = false,
                    ResponseCode = "99", 
                    ResponseMessage = "Error occurred"
                };
            }
        }

        public async Task<GenericResponse<GetHospitalResponse>> GetHospitalAsync(string hospitalId)
        {
            _logger.LogInformation($"Inside the GetHospitalAsync");
            _logger.LogInformation($"payload to get a hospital is {hospitalId}");

            try
            {
                var hospitalEntity = await _repositoryManager.Hospital.GetHospitalsByHospitalIdAsync(hospitalId, trackChanges: false);
                _logger.LogInformation($"Response from the database while getting the hospital is  {hospitalEntity}.   -------- HospitalId:{hospitalId}");
                if (hospitalEntity == null)
                {
                    _logger.LogInformation($"fetch hospital response is null");
                    return new GenericResponse<GetHospitalResponse>()
                    {
                        IsSuccessful = false,
                        ResponseCode = "99",
                        ResponseMessage = "No hospital record found"
                    };
                }

                var mapHospitalEntityToResponseDto = _mapper.Map<GetHospitalResponse>(hospitalEntity);
                return new GenericResponse<GetHospitalResponse>()
                {
                    IsSuccessful = true,
                    ResponseCode = "00",
                    ResponseMessage = "Hospital record fetched successfully",
                    Data = mapHospitalEntityToResponseDto
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occur while creating a new hospital. Error message : {ex.Message}");
                return new GenericResponse<GetHospitalResponse>()
                {
                    IsSuccessful = false,
                    ResponseCode = "99",
                    ResponseMessage = "Error occurred"
                };
            }
        }


        public async Task<GenericResponse<IEnumerable<GetHospitalResponse>>> GetAllHospitalsAsync()
        {
            _logger.LogInformation($"Inside the GetAllHospitalsAsync");

            try
            {
                var hospitalEntities = await _repositoryManager.Hospital.GetAllHospitals();
                if (!hospitalEntities.Any())
                {

                    _logger.LogInformation($"No any hospital record found");
                    return new GenericResponse<IEnumerable<GetHospitalResponse>>()
                    {
                        IsSuccessful = false,
                        ResponseCode = "99",
                        ResponseMessage = "No hospital record found"
                    };
                }

                var mapHospitalEntitiesToResponseDto = _mapper.Map<IEnumerable<GetHospitalResponse>>(hospitalEntities);

                return new GenericResponse<IEnumerable<GetHospitalResponse>>()
                {
                    IsSuccessful = true,
                    ResponseCode = "00",
                    ResponseMessage = "Hospital record fetched successfully",
                    Data = mapHospitalEntitiesToResponseDto
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occur while creating all hospitals. Error message : {ex.Message}");
                return new GenericResponse<IEnumerable<GetHospitalResponse>>()
                {
                    IsSuccessful = false,
                    ResponseCode = "99",
                    ResponseMessage = "Error occurred"
                };
            }
        }



        public async Task<GenericResponse<string>> UpdateHospitalAsync(UpdateHospitalDto request)
        {
            _logger.LogInformation($"Inside the UpdateHospitalAsync");
            _logger.LogInformation($"payload to upload  hospital record  is {request}");

            try
            {
                var hospitalEntity = await _repositoryManager.Hospital.GetHospitalsByHospitalIdAsync(request.HospitalId, trackChanges: false);
                _logger.LogInformation($"Response from the database while getting the hospital is  {hospitalEntity}.   -------- HospitalId:{request.HospitalId}");
                if (hospitalEntity == null)
                {
                    _logger.LogInformation($"No response for the hospital id {request.HospitalId}");
                    return new GenericResponse<string>()
                    {
                        IsSuccessful = false,
                        ResponseCode = "99",
                        ResponseMessage = "No hospital record found"
                    };
                }
                hospitalEntity.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : hospitalEntity.Name;
                hospitalEntity.PhoneNumber = !string.IsNullOrEmpty(request.PhoneNumber) ? request.Name : hospitalEntity.PhoneNumber;
                hospitalEntity.Logo = !string.IsNullOrEmpty(request.Logo) ? request.Logo : hospitalEntity.Logo;
                hospitalEntity.Description = !string.IsNullOrEmpty(request.Description) ? request.Description : hospitalEntity.Description;
                _repositoryManager.Hospital.UpdateHospital(hospitalEntity);
                await _repositoryManager.SaveAsync();
                _logger.LogError($"{hospitalEntity} record saved in our database successfully");
                return new GenericResponse<string>()
                {
                    IsSuccessful = true,
                    ResponseCode = "00",
                    ResponseMessage = "Hospital record updated successfully",
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occur while updating a hospital record. Error message : {ex.Message}");
                return new GenericResponse<string>()
                {
                    IsSuccessful = false,
                    ResponseCode = "99",
                    ResponseMessage = "Error occurred"
                };
            }
        }
    }
}
