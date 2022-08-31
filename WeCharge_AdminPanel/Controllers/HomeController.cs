using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeCharge.BAL.Services.Implementation;
using WeCharge.BAL.Services.Interface;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
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
            var dashboardCountData = await _ordersServices.GetDashboardCount("wecharge.USP_GET_DASHBOARD_COUNT",null).ConfigureAwait(true);

            return View(dashboardCountData);
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