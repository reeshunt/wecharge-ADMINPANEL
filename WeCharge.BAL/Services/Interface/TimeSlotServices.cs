using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.BAL.Services.Implementation;
using WeCharge.DAL.Repository;
using WeCharge.Model;
using WeCharge.Model.DTO;

namespace WeCharge.BAL.Services.Interface
{
    public class TimeSlotServices : ITimeSlotServices
    {
        private readonly IRepository<TimeSlot> _repository;
        private readonly IRepository<TimeSlotDTO> _viewrepository;

        public TimeSlotServices(IRepository<TimeSlot> repository, IRepository<TimeSlotDTO> viewrepository)
        {
            _repository = repository;
            _viewrepository = viewrepository;
        }

        public async Task<IEnumerable<TimeSlotDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param);
        }
    }
}
