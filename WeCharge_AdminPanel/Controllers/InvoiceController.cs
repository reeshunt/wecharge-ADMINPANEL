using Microsoft.AspNetCore.Mvc;

namespace WeCharge_AdminPanel.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
