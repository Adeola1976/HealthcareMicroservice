using AutoMapper;
using Hospital.Application.Interface.Repository;
using Hospital.Application.Interface.Service;
using Hospital.Application.Utility;
using Hospital.Domain;
using Hospital.Domain.DTOs.Request;
using Hospital.Domain.DTOs.Response;
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
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHospitalService> _hospitalService;
        public ServiceManager(IRepositoryManager repositoryManager, ILogger<HospitalService> hospitallogger,
        IMapper mapper,IHttpService httpService, IConfiguration configure)
        {
            _hospitalService = new Lazy<IHospitalService>(() => new HospitalService(repositoryManager, mapper, hospitallogger,httpService, configure));

        }

        public IHospitalService HospitalService => _hospitalService.Value;

    }
}