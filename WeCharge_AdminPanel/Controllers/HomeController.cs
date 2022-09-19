using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using WeCharge.BAL.Services.Implementation;
using WeCharge.BAL.Services.Interface;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountServices _accountServices ;
        private readonly IOrdersServices _ordersServices;


        public HomeController(ILogger<HomeController> logger, IAccountServices accountServices, IOrdersServices ordersServices)
        {
            _accountServices = accountServices;
            _ordersServices = ordersServices;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardCountData = await _ordersServices.GetDashboardCount("wecharge.USP_GET_DASHBOARD_COUNT", null).ConfigureAwait(true);
            
            return View(dashboardCountData);
        }
        public async Task<JsonResult> getGraphData(string year)
        {
            DynamicParameters cParameters = new DynamicParameters();
            cParameters.Add("@YEAR", year);
            var graphData = await _ordersServices.GetGraphDataForEarnings("wecharge.USP_GET_EARNING_GRAPH_DATA_ADMIN_PANEL", cParameters).ConfigureAwait(true);
            return new JsonResult(new { graphData });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}