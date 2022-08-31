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
    public class ReserveServices : IReserveServices
    {
        private readonly IRepository<Fuel> _fuel;
        private readonly IRepository<PaymentMode> _paymentMode;
        private readonly IRepository<TimeSlot> _timeSlot;
        private readonly IRepository<TimeSlotDTO> _timeSlotDTO;
        public ReserveServices(IRepository<Fuel> fuel, IRepository<TimeSlotDTO> timeSlotDTO, IRepository<PaymentMode> paymentMode, IRepository<TimeSlot> timeSlot)
        {
            _timeSlotDTO = timeSlotDTO;
            _fuel = fuel;
            _paymentMode = paymentMode;
            _timeSlot = timeSlot;
        }


        public async Task<IEnumerable<Fuel>> GetAllFuel()
        {
            return await _fuel.GetAllAsync();
        }


        public async Task<IEnumerable<PaymentMode>> GetAllPaymentMode()
        {
            return await _paymentMode.GetAllAsync();
        }

        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlot()
        {
            return await _timeSlot.GetAllAsync();
        }

        public async Task<IEnumerable<TimeSlotDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _timeSlotDTO.GetAllByQuery(procedureName, param);
        }
    }
}
