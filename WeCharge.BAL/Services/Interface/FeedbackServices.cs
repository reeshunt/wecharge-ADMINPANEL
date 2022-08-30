using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.BAL.Services.Implementation;
using WeCharge.DAL.Repository;
using WeCharge.Model.DTO;

namespace WeCharge.BAL.Services.Interface
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IRepository<FeedbackDTO> _viewrepository;

        public FeedbackServices(IRepository<FeedbackDTO> viewrepository)
        {
            _viewrepository = viewrepository;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetDisplayByQuerry(string procedureName, DynamicParameters param)
        {
            return await _viewrepository.GetAllByQuery(procedureName, param);
        }
    }
}
