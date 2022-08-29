using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.DAL.Repository
{
    public interface IRepository<T> : IDisposable where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entity, string tableName);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<int> DeleteAll(string tableName);
        Task<bool> IsExists(string procedureName, DynamicParameters param);
        Task<T> GetByQuery(string procedureName, DynamicParameters param);
        Task<IEnumerable<T>> GetAllByQuery(string procedureName, DynamicParameters param);
    }
}
