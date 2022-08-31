using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.DAL.Repository;
using WeCharge.Model;

namespace WeCharge.BAL.Services.Implementation
{
    public class WalletServices : IWallet
    {
        private readonly IRepository<Wallet> _repository;

        public WalletServices(IRepository<Wallet> repository)
        {
            _repository = repository;
        }

        public async Task<Wallet> GetByID(int? id)
        {
            try
            {
                return await _repository.GetByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Wallet>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _repository.GetAllByQuery(procedureName, param).ConfigureAwait(false);
        }

        public async Task<bool> UpdateWallet(Wallet wallet)
        {
            try
            {
                bool result = await _repository.UpdateAsync(wallet).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
