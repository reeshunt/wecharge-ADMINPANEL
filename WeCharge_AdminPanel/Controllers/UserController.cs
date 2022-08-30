using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeCharge.BAL.Services.Implementation;
using WeCharge.Model;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountServices _accountServices;
        public UserController(ILogger<HomeController> logger, IAccountServices accountServices)
        {
            _accountServices = accountServices;
            _logger = logger;
        }

        //public Task<IActionResult> Add()
        //{
        //    return View();
        //}

        public async Task<IActionResult> View()
        {
            List<Users> userData = new List<Users>();
            userData = await _accountServices.GetAll().ConfigureAwait(false);
            return View(userData);
        }
        

       
    }
}