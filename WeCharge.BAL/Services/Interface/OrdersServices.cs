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
        private readonly IRepository<DashboardCountDTO> _dashboardrepository;

        public OrdersServices(IRepository<OrdersDTO> viewrepository, IRepository<DashboardCountDTO> dashboardRepository)
        {
            _viewrepository = viewrepository;
            _dashboardrepository = dashboardRepository;
        }

        public async Task<IEnumerable<OrdersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param);
        }
        public async Task<DashboardCountDTO> GetDashboardCount(string procedureName, DynamicParameters param)
        {
            return await _dashboardrepository.GetByQuery(procedureName, param);
        }
    }
}
