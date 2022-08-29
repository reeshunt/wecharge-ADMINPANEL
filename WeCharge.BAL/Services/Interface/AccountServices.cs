using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.BAL.Services.Implementation;
using WeCharge.DAL.Repository;
using WeCharge.Model;

namespace WeCharge.BAL.Services.Interface
{
    public class AccountServices : IAccountServices
    {
        private readonly IRepository<Users> _repository;

        public AccountServices(IRepository<Users> repository)
        {
            _repository = repository;
        }

        public async Task<List<Users>> GetAll()
        {
             return (List<Users>)await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Users> GetByQuerry(string procedureName, DynamicParameters param)
        {
            return await _repository.GetByQuery(procedureName, param).ConfigureAwait(false);
        }


    }
}
