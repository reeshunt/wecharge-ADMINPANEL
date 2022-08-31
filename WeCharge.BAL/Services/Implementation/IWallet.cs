using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model;

namespace WeCharge.BAL.Services.Implementation
{
    public interface IWallet
    {
        Task<IEnumerable<Wallet>> GetDisplayByQuerry(string procedureName, DynamicParameters param);
        Task<Wallet> GetByID(int? id);
        Task<bool> UpdateWallet(Wallet assets);
    }
}
