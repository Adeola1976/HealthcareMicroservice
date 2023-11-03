using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;
using User.Application.Interface.Service;
using User.Application.Utility;
using User.Domain;
using User.Domain.DTOs.Request;
using User.Domain.DTOs.Response;

namespace User.Infrastructure.Implementation.Service
{
    public  class UserHospitalService : IUserHospitalService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<UserHospitalService> _logger;
        private readonly IMapper _mapper;


        public UserHospitalService(IRepositoryManager repositoryManager, IMapper mapper, ILogger<UserHospitalService> logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenericResponse<string>> CreateUserHospitalAsync(UserHospitalForCreationDto request)
        {
            _logger.LogInformation($"Inside the CreateUserHospitalAync");
            _logger.LogInformation($"payload to create a new user hospital is {request}");

            try
            {

                var userHospitalEntity = await _repositoryManager.UserHospital.GetUserHospitalsByHospitalIdAsync(request.HospitalId, trackChanges: false);    
                if (userHospitalEntity != null)
                {
                    return new GenericResponse<string>()
                    {
                        IsSuccessful = true,
                        ResponseCode = "99",
                        ResponseMessage = "Hospital already exist"
                    };
                }
                var hospitalEntity = _mapper.Map<UserHospital>(request);
                hospitalEntity.UserHospitalId = Guid.NewGuid().ToString();
                _repositoryManager.UserHospital.CreateUserHospital(hospitalEntity);
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

        public async Task<GenericResponse<GetUserHospitalResponse>> GetUserHospitalAsync(string hospitalId)
        {
            _logger.LogInformation($"Inside the GetHospitalAsync");
            _logger.LogInformation($"payload to get a hospital is {hospitalId}");

            try
            {
                var hospitalEntity = await _repositoryManager.UserHospital.GetUserHospitalsByHospitalIdAsync(hospitalId, trackChanges: false);
                _logger.LogInformation($"Response from the database while getting the hospital is  {hospitalEntity}.   -------- HospitalId:{hospitalId}");
                if (hospitalEntity == null)
                {
                    _logger.LogInformation($"fetch hospital response is null");
                    return new GenericResponse<GetUserHospitalResponse>()
                    {
                        IsSuccessful = false,
                        ResponseCode = "99",
                        ResponseMessage = "No hospital record found"
                    };
                }

                var mapHospitalEntityToResponseDto = _mapper.Map<GetUserHospitalResponse>(hospitalEntity);
                return new GenericResponse<GetUserHospitalResponse>()
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
                return new GenericResponse<GetUserHospitalResponse>()
                {
                    IsSuccessful = false,
                    ResponseCode = "99",
                    ResponseMessage = "Error occurred"
                };
            }
        }

        public async Task<GenericResponse<IEnumerable<GetUserHospitalResponse>>> GetAllUserHospitalsAsync()
        {
            _logger.LogInformation($"Inside the GetAllHospitalsAsync");

            try
            {
                var hospitalEntities = await _repositoryManager.UserHospital.GetAllUserHospitals();
                if (!hospitalEntities.Any())
                {

                    _logger.LogInformation($"No any hospital record found");
                    return new GenericResponse<IEnumerable<GetUserHospitalResponse>>()
                    {
                        IsSuccessful = false,
                        ResponseCode = "99",
                        ResponseMessage = "No hospital record found"
                    };
                }

                var mapHospitalEntitiesToResponseDto = _mapper.Map<IEnumerable<GetUserHospitalResponse>>(hospitalEntities);
                return new GenericResponse<IEnumerable<GetUserHospitalResponse>>()
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
                return new GenericResponse<IEnumerable<GetUserHospitalResponse>>()
                {
                    IsSuccessful = false,
                    ResponseCode = "99",
                    ResponseMessage = "Error occurred"
                };
            }
        }
    }
}
