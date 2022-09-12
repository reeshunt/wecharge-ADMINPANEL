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
    public interface ITimeSlotServices
    {
        Task<IEnumerable<TimeSlotDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param);
        Task<int> Add(TimeSlot timeSlot );
        Task<bool> Update(TimeSlot timeSlot );
        Task<TimeSlot> GetById(int id);
        Task<bool> Delete(TimeSlot timeSlot);
        

    }
}
