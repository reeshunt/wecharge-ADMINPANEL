using Microsoft.AspNetCore.Mvc;

namespace WeCharge_AdminPanel.Controllers
{
    public class CoupanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
