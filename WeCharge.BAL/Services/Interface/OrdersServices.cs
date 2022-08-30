using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.BAL.Services.Implementation;
using WeCharge.DAL.Repository;
using WeCharge.Model.DTO;
using WeCharge.Model;
using Dapper;

namespace WeCharge.BAL.Services.Interface
{
    public class OrdersServices : IOrdersServices
    {
        private readonly IRepository<OrdersDTO> _viewrepository;

        public OrdersServices(IRepository<OrdersDTO> viewrepository)
        {
            _viewrepository = viewrepository;
        }

        public async Task<IEnumerable<OrdersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param);
        }
    }
}
