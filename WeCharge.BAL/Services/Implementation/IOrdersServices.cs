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
    public interface IOrdersServices
    {
        Task<IEnumerable<OrdersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param);
        Task<DashboardCountDTO> GetDashboardCount(string procedureName, DynamicParameters param);
        Task<IEnumerable<EarningGraphDataDTOs>> GetGraphDataForEarnings(string procedureName, DynamicParameters param);
        Task<int> AddOrder(Orders orders);
        Task<List<OrderId>> GetAllOrderId();
        Task<int> AddOrderId(OrderId orderId);
    }
}
