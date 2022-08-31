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
    public class AssetServices : IAssetServices
    {
        private readonly IRepository<Assets> _repository;

        public AssetServices(IRepository<Assets> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAssets(Assets assets)
        {
            try
            {
                return await _repository.AddAsync(assets);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAssets(Assets assets)
        {
            try
            {
                bool result = await _repository.UpdateAsync(assets).ConfigureAwait(false);
                return result;
            }
            catch(Exception ex) { throw ex; }
        }

        public async Task<List<Assets>> GetAll()
        {
             return (List<Assets>)await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Assets> GetByID(int? id)
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

        public async Task<Assets> GetByQuerry(string procedureName, DynamicParameters param)
        {
            return await _repository.GetByQuery(procedureName, param).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAssets(Assets assets)
        {
            try
            {
                bool result = await _repository.UpdateAsync(assets).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
