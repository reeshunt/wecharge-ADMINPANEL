using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model;

namespace WeCharge.BAL.Services.Implementation
{
    public interface IAccountServices
    {
        Task<Users> GetByQuerry(string procedureName, DynamicParameters param);
        Task<List<Users>> GetAll();
    }
}
