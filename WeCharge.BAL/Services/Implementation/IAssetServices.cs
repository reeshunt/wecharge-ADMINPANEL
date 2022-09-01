using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model;
using WeCharge.Model.DTO;

namespace WeCharge.BAL.Services.Implementation
{
    public interface IAssetServices
    {
        Task<Assets> GetByQuerry(string procedureName, DynamicParameters param);
        Task<AssetDTOs> GetByQuerryAssets(string procedureName, DynamicParameters param);
        Task<IEnumerable<Assets>> GetALlByQuerry(string procedureName, DynamicParameters param);
        Task<Assets> GetByID(int? id);
        Task<List<Assets>> GetAll();
        Task<int> AddAssets(Assets assets);
        Task<bool> DeleteAssets(Assets assets);
        Task<bool> UpdateAssets(Assets assets);
    }
}
