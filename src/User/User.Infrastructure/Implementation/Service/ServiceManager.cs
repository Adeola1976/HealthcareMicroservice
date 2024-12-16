using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;
using User.Application.Interface.Service;

namespace User.Infrastructure.Implementation.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserHospitalService> _userHospitalService;
        public ServiceManager(IRepositoryManager repositoryManager, ILogger<UserHospitalService> userhospitallogger,
        IMapper mapper)
        {
            _userHospitalService = new Lazy<IUserHospitalService>(() => new UserHospitalService(repositoryManager, mapper, userhospitallogger));

        }

        public IUserHospitalService UserHospitalService => _userHospitalService.Value;

    }
}
