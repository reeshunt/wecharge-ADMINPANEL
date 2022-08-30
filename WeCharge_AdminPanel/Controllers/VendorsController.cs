using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge_AdminPanel.Models;
using System.Linq;
using AutoMapper;
using WeCharge.Model;

namespace WeCharge_AdminPanel.Controllers
{
    public class VendorsController : Controller
    {
        private readonly ILogger<VendorsController> _logger;
        private readonly IAccountServices _accountServices;
        private readonly IMapper _mapper;

        public VendorsController(ILogger<VendorsController> logger, IMapper mapper , IAccountServices accountServices)
        {
            _mapper= mapper;
            _accountServices = accountServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
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
                var displayResult = await _accountServices.GetDisplayByQuerry("wecharge.USP_GetVendors", myParams).ConfigureAwait(true);
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

        [HttpPost]
        public async Task<IActionResult> Add(UsersViewModel usersViewModel)
        {
            var proMap = _mapper.Map<Users>(usersViewModel);
            proMap.CREATED_DATE = DateTime.Now;
            proMap.MODOFIED_DATE = DateTime.Now;
            proMap.IMAGE_PATH = "http://103.205.66.213:3000/image/avatar1.jpg";
            proMap.IS_ACTIVE = true;
            proMap.ROLE_ID = 3;
            proMap.PASSWORD_HASH = "$2b$10$Lzx9ZXkz6t1I2ZySz.Jf/uOgnxPEu386tx96bZ9XRqkVHijcksjJS";
            await _accountServices.AddVendor(proMap);
            return View();
        }
    }
}
