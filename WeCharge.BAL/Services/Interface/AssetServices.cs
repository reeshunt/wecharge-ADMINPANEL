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
    public class AssetServices : IAssetServices
    {
        private readonly IRepository<Assets> _repository;
        private readonly IRepository<AssetDTOs> _viewrepository;

        public AssetServices(IRepository<Assets> repository, IRepository<AssetDTOs> viewrepository)
        {
            _viewrepository=viewrepository;
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

        public async Task<IEnumerable<Assets>> GetALlByQuerry(string procedureName, DynamicParameters param)
        {
            return await _repository.GetAllByQuery(procedureName, param).ConfigureAwait(false);
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

		public async Task<AssetDTOs> GetByQuerryAssets(string procedureName, DynamicParameters param)
		{
			return await _viewrepository.GetByQuery(procedureName,param).ConfigureAwait(false);
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
