using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge.BAL.Services.Interface;
using WeCharge.Model;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersServices _ordersServices;
        private readonly IAccountServices _accountServices;
        private readonly IReserveServices _reserveServices;
        private readonly IAssetServices _assetServices;
        private readonly IMapper _mapper;

        public OrdersController(ILogger<OrdersController> logger, IAssetServices assetServices, IReserveServices reserveServices, IAccountServices accountServices, IMapper mapper, IOrdersServices ordersServices)
        {
            _assetServices = assetServices;
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
                var UserList = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_Users_Customers", null);
                var Users = UserList.ToList().Select(x=>new Users {ID = x.ID,EMAIL = x.EMAIL}).Distinct(); 
                ViewBag.Users = Users;

                ViewBag.VendorName = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_ActiveVendors", null);
                ViewBag.Fuel = await _reserveServices.GetAllFuel();
                ViewBag.TimeSlot = await _reserveServices.GetDisplayByQuerry("wecharge.USP_Get_Time_Slot_Admin", null);
                ViewBag.PaymentMode = await _reserveServices.GetAllPaymentMode();
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddOrder(OrdersViewModel ordersViewModel)

        {
            try
            {
                var proMap = _mapper.Map<Orders>(ordersViewModel);
                OrderId orderIdModel = new();
                var getOrderId = await _ordersServices.GetAllOrderId();
                if (getOrderId.Any())
                {
                    var orderid = getOrderId.LastOrDefault().ORDER_ID;
                    orderIdModel.ORDER_ID = orderid + 1;
                    await _ordersServices.AddOrderId(orderIdModel);
                }
                var myParams = new DynamicParameters();
                myParams.Add("@userId", ordersViewModel.USER_ID);
                var getUserAddress = await _accountServices.GetByIdAdress(ordersViewModel.ADDRESS_ID);
                if (getUserAddress != null)
                {
                    proMap.DELIVERY_ADDRESS = getUserAddress.ADDRESS + ", " + getUserAddress.ADDRESS_PINCODE;
                }

            

                proMap.ORDER_ID = (int)orderIdModel.ORDER_ID;
                proMap.CREATED_DATE = DateTime.Now;
                proMap.MODOFIED_DATE = DateTime.Now;
                proMap.ORDER_DATETIME = DateTime.Now;
                await _ordersServices.AddOrder(proMap);
                return Json(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Get User Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        public async Task<JsonResult> GetBillingAddress(int adressId, int userId)
        {

            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@userId", userId);
                var getTheData = await _accountServices.GetByQuerryForAddress("wecharge.USP_Get_Users_Address", myParams);
                if (getTheData != null)
                {
                    Address address = getTheData.FirstOrDefault(x => x.ID == adressId);
                    if (address != null)
                    {
                        if (address.IS_BILLING_ADDRESS == true)
                        {
                            return Json(true);
                        }
                    }
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// get the assets
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="fuelTypeId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetAssets(int userId, int fuelTypeId)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@FUEL_ID", fuelTypeId);
                myParams.Add("@USER_ID", userId);
                var getTheData = await _assetServices.GetALlByQuerry("wecharge.USP_Get_Asset_By_UserId_and_FuelID_Admin", myParams);
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

        public async Task<IActionResult> GetFuelPrice(int vendorId, int fuelTypeId, string coupanCode, int quantity)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@FUEL_ID", fuelTypeId);
                myParams.Add("@VENDOR_ID", vendorId);
                myParams.Add("@COUPON_CODE", coupanCode);
                myParams.Add("@QUANTITY", quantity);
                var getTheData = await _assetServices.GetByQuerryAssets("wecharge.USP_Get_Fuel_Price_By_VendorId", myParams);
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
                foreach (var item in displayResult)
                {
                    item.ORDER_DATETIME_STR = item.ORDER_DATETIME.ToString("dd/MM/yyyy");
                }
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
