using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model;

namespace WeCharge.BAL.Services.Implementation
{
    public interface IAssetServices
    {
        Task<Assets> GetByQuerry(string procedureName, DynamicParameters param);
        Task<Assets> GetByID(int? id);
        Task<List<Assets>> GetAll();
        Task<int> AddAssets(Assets assets);
        Task<bool> DeleteAssets(Assets assets);
        Task<bool> UpdateAssets(Assets assets);
    }
}
