using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeCharge.BAL.Services.Implementation;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountServices _accountServices ;

        public HomeController(ILogger<HomeController> logger, IAccountServices accountServices)
        {
            _accountServices = accountServices;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var test = await _accountServices.GetAll().ConfigureAwait(false);
            return View();
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