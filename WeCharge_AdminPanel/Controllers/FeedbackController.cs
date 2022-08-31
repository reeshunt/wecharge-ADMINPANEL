using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ILogger<FeedbackController> _logger;
        private readonly IFeedbackServices _feedbackServices;
        private readonly IMapper _mapper;

        public FeedbackController(ILogger<FeedbackController> logger, IMapper mapper, IFeedbackServices feedbackServices)
        {
            _mapper = mapper;
            _logger = logger;
            _feedbackServices = feedbackServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllVendors(JqueryDatatableParam param)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@skip", param.iDisplayStart);
                myParams.Add("@take", param.iDisplayLength);
                myParams.Add("@search_key", param.sSearch);
                var displayResult = await _feedbackServices.GetDisplayByQuerry("wecharge.USP_GetFeedback_Datatable", myParams).ConfigureAwait(true);
                var totalRecords = displayResult.Any() ? displayResult.First().TotalRecords : 0;
                return Json(new
                {
                    param.sEcho,
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalRecords,
                    aaData = displayResult
                });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
