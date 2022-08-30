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
    public interface IAccountServices
    {
        Task<Users> GetByQuerry(string procedureName, DynamicParameters param);
        Task<IEnumerable<UsersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param);
        Task<Users> GetById(int iD);
        Task<int> AddVendor(Users users);
        Task<bool> UpdateVendor(Users users);
        Task<List<Users>> GetAll();
    }
}
