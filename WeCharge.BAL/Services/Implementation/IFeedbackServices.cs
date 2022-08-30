using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.DTO;

namespace WeCharge.BAL.Services.Implementation
{
    public interface IFeedbackServices
    {
        Task<IEnumerable<FeedbackDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param);
    }
}
