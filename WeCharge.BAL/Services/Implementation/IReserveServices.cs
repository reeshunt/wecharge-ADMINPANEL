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
    public interface IReserveServices
    {
        Task<IEnumerable<TimeSlotDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param);
        Task<IEnumerable<TimeSlot>> GetAllTimeSlot();
        Task<IEnumerable<PaymentMode>> GetAllPaymentMode();
        Task<IEnumerable<Fuel>> GetAllFuel();
    }
}
