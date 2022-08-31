using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge.BAL.Services.Interface;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersServices _ordersServices;
        private readonly IAccountServices _accountServices;
        private readonly IReserveServices _reserveServices;
        private readonly IMapper _mapper;

        public OrdersController(ILogger<OrdersController> logger, IReserveServices reserveServices, IAccountServices accountServices, IMapper mapper, IOrdersServices ordersServices)
        {
            _reserveServices = reserveServices;
            _accountServices = accountServices;
            _mapper = mapper;
            _ordersServices = ordersServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Users = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_Users_Customers", null);
                ViewBag.VendorName = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_ActiveVendors", null);
                ViewBag.Fuel = await _reserveServices.GetAllFuel();
                ViewBag.TimeSlot = await _reserveServices.GetDisplayByQuerry("wecharge.USP_Get_Time_Slot", null);
                ViewBag.PaymentMode = await _reserveServices.GetAllPaymentMode();
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<JsonResult> GetUserAddress(int id)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@userId", id);
                var getTheData = await _accountServices.GetByQuerryForAddress("wecharge.USP_Get_Users_Address", myParams);
                if (getTheData != null)
                {
                    return Json(getTheData);
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Get list of vendors by JSON
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetAllOrders(JqueryDatatableParam param)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@skip", param.iDisplayStart);
                myParams.Add("@take", param.iDisplayLength);
                myParams.Add("@search_key", param.sSearch);
                var displayResult = await _ordersServices.GetDisplayByQuerry("wecharge.USP_GetORDERS_Datatable", myParams).ConfigureAwait(true);
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
