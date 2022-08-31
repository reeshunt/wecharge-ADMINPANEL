using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.BAL.Services.Implementation;
using WeCharge.DAL.Repository;
using WeCharge.Model;
using WeCharge.Model.DTO;

namespace WeCharge.BAL.Services.Interface
{
    public class AccountServices : IAccountServices
    {
        private readonly IRepository<Users> _repository;
        private readonly IRepository<UsersDTO> _viewrepository;
        private readonly IRepository<Address> _classRepository;

        public AccountServices(IRepository<Users> repository, IRepository<Address> classRepository, IRepository<UsersDTO> viewrepository)
        {
            _classRepository=classRepository;
            _repository = repository;
            _viewrepository = viewrepository;
        }

        public async Task<int> AddVendor(Users users)
        {
             return await _repository.AddAsync(users);
        }
         
        public async Task<List<Users>> GetAll()
        {
             return (List<Users>)await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Users> GetById(int iD)
        {
            return await _repository.GetByIdAsync(iD);
        }

        public async Task<Users> GetByQuerry(string procedureName, DynamicParameters param)
        {
            return await _repository.GetByQuery(procedureName, param).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Address>> GetByQuerryForAddress(string procedureName, DynamicParameters param)
        {
            return await _classRepository.GetAllByQuery(procedureName, param);
        }

        public async Task<IEnumerable<UsersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param).ConfigureAwait(false);
        }

        public async Task<bool> UpdateVendor(Users users)
        {
            return await _repository.UpdateAsync(users);
        }
    }
}
