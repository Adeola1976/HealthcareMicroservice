using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;

namespace User.Infrastructure.Implementation.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserHospitalRepository> _userHospitalRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userHospitalRepository = new Lazy<IUserHospitalRepository>(() => new UserHospitalRepository(_repositoryContext));
       
        }
        public IUserHospitalRepository UserHospital => _userHospitalRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

    }
}
