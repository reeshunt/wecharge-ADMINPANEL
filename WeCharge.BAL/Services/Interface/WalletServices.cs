using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.DAL.Repository;
using WeCharge.Model;
using WeCharge.Model.DTO;

namespace WeCharge.BAL.Services.Implementation
{
    public class WalletServices : IWallet
    {
        private readonly IRepository<Wallet> _repository;
        private readonly IRepository<WalletDTO> _dtoRepository;

        public WalletServices(IRepository<Wallet> repository, IRepository<WalletDTO> dtorepository)
        {
            _repository = repository;
            _dtoRepository = dtorepository;
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

        public async Task<IEnumerable<WalletDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _dtoRepository.GetAllByQuery(procedureName, param).ConfigureAwait(false);
        }

        public async Task<bool> UpdateWallet(Wallet wallet)
        {
            return await _repository.UpdateAsync(wallet).ConfigureAwait(false);
        }
    }
}
