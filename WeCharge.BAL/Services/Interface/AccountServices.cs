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

        public AccountServices(IRepository<Users> repository, IRepository<UsersDTO> viewrepository)
        {
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

        public async Task<Users> GetByQuerry(string procedureName, DynamicParameters param)
        {
            return await _repository.GetByQuery(procedureName, param).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UsersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param).ConfigureAwait(false);
        }
    }
}
