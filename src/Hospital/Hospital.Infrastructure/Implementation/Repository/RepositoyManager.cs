using Hospital.Application.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Implementation.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IHospitalRepository> _hospitalRepository;
        private readonly Lazy<IStaffRepository> _staffRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _hospitalRepository = new Lazy<IHospitalRepository>(() => new HospitalRepository(_repositoryContext));
            _staffRepository = new Lazy<IStaffRepository>(() => new StaffRepository(_repositoryContext));
        }

        public IHospitalRepository Hospital => _hospitalRepository.Value;
        public IStaffRepository Staff => _staffRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

    }
}
