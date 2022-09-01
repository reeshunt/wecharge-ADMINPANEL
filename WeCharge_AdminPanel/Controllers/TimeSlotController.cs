using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
	public class TimeSlotController : Controller
	{
        private readonly ILogger<TimeSlotController> _logger;
        private readonly ITimeSlotServices _timeSlotServices ;
        public TimeSlotController(ILogger<TimeSlotController> logger, ITimeSlotServices timeSlotServices)
        {
            _timeSlotServices = timeSlotServices;
            _logger = logger;
        }

        public IActionResult Index()
		{
			return View();
		}

        public async Task<IActionResult> GetAllTimeSlot(JqueryDatatableParam param)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@skip", param.iDisplayStart);
                myParams.Add("@take", param.iDisplayLength);
                myParams.Add("@search_key", param.sSearch);
                var displayResult = await _timeSlotServices.GetDisplayByQuerry("wecharge.USP_GetTIMESLOT_Datatable", myParams).ConfigureAwait(true);
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
