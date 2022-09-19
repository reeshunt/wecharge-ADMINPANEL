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
        private readonly IRepository<Orders> _repository;
        private readonly IRepository<OrderId> _repository1;
        private readonly IRepository<DashboardCountDTO> _dashboardrepository;
        private readonly IRepository<EarningGraphDataDTOs> _graphrepository;

        public OrdersServices(IRepository<OrdersDTO> viewrepository, IRepository<OrderId> repository1, IRepository<Orders> repository, IRepository<DashboardCountDTO> dashboardRepository,
            IRepository<EarningGraphDataDTOs> graphRepository)
        {
            _repository1 = repository1;
            _repository = repository;
            _viewrepository = viewrepository;
            _dashboardrepository = dashboardRepository;
            _graphrepository = graphRepository;
        }

        public async Task<IEnumerable<OrdersDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param);
        }
        public async Task<DashboardCountDTO> GetDashboardCount(string procedureName, DynamicParameters param)
        {
            return await _dashboardrepository.GetByQuery(procedureName, param);
        }
        public async Task<IEnumerable<EarningGraphDataDTOs>> GetGraphDataForEarnings(string procedureName, DynamicParameters param)
        {
            return await _graphrepository.GetAllByQuery(procedureName, param);
        }

        public async Task<List<OrderId>> GetAllOrderId()
        {
            return (List<OrderId>)await _repository1.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<int> AddOrder(Orders orders)
        {
            return await _repository.AddAsync(orders);
        }

        public async Task<bool> UpdateOrder(Orders orders)
        {
            return await _repository.UpdateAsync(orders);
        }

        public async Task<Orders> GetByID(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> AddOrderId(OrderId orderId)
        {
            return await _repository1.AddAsync(orderId);
        }
    }
}
