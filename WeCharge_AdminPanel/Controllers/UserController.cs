using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WeCharge.BAL.Services.Implementation;
using WeCharge.Model;
using WeCharge.Model.DTO;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountServices _accountServices;
        private readonly IAssetServices _assetServices;
        private readonly IWallet _walletServices;
        public UserController(ILogger<HomeController> logger, IAccountServices accountServices, IAssetServices assetServices, IWallet walletServices)
        {
            _accountServices = accountServices;
            _assetServices = assetServices;
            _logger = logger;
            _walletServices = walletServices;

        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<Users> userData = new List<Users>();
            userData = await _accountServices.GetAll().ConfigureAwait(false);
            return View(userData);
        }
        public async Task<JsonResult> checkEmail(string val)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@emailId", val);
                var exists = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_User_Email", myParams);
                    if (exists != null)
                {
                    return Json(exists.Count()>0?true:false);
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<JsonResult> CheckMobile(string val)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@mobile", val);
                var exists = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_User_Mobile", myParams);
                    if (exists != null)
                {
                    return Json(exists.Count()>0?true:false);
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEditAsset(int? id)
        {
            List<Users> userData = await _accountServices.GetAll().ConfigureAwait(false);
            ViewBag.UsersList = userData.OrderBy(u => u.FULL_NAME).Select(us => new SelectListItem { Value = us.ID.ToString(), Text = us.FULL_NAME }).ToList();
            if (id == null)
            {
                return View("CreateAsset");
            }
            else
            {
                Assets assets = await _assetServices.GetByID(id).ConfigureAwait(false);
                if (assets == null)
                    return NotFound();
                else
                    return View("CreateAsset", assets);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsset(Assets assets)
        {
            if (!ModelState.IsValid) return RedirectToAction("CreateAsset");

            if (assets.ID == null)
            {
                assets.CREATED_DATE = DateTime.Now;
                assets.MODIFIED_DATE = DateTime.Now;
                assets.IS_ACTIVE = true;
                _assetServices.AddAssets(assets);
            }
            else
            {
                Assets _assets = await _assetServices.GetByID(assets.ID).ConfigureAwait(false);
                _assets.MODIFIED_DATE = DateTime.Now;
                _assets.MODIFIED_BY = "1";
                //_assets.IS_ACTIVE = assets.IS_ACTIVE;
                _assets.EQUIPMENT_NAME = assets.EQUIPMENT_NAME;
                _assets.MOBILE_NO = assets.MOBILE_NO;
                _assets.EMAIL = assets.EMAIL;
                _assetServices.UpdateAssets(_assets);
            }
            return RedirectToAction("Assets");
        }
        public async Task<IActionResult> Assets()
        {
            List<Assets> data = new List<Assets>();
            data = await _assetServices.GetAll().ConfigureAwait(false);
            return View(data);
        }
        //public async Task<IActionResult> EditAsset(int id)
        //{
        //    Assets assets = await _assetServices.GetByID(id).ConfigureAwait(false);
        //    if (assets != null)
        //    {

        //    }
        //    else { }
        //}
        public async Task<IActionResult> DeleteAssets(int id)
        {
            Assets assets = await _assetServices.GetByID(id).ConfigureAwait(false);
            bool result = false;
            if (assets != null)
            {
                assets.IS_ACTIVE = false;
                assets.MODIFIED_DATE = DateTime.Now;
                assets.MODIFIED_BY = "1";
                result = await _assetServices.DeleteAssets(assets).ConfigureAwait(false);
            }

            return RedirectToAction("Assets");



        }


        public IActionResult Wallet()
        {
            return View("Wallet");
        }

        public async Task<IActionResult> GetUsersWallet(JqueryDatatableParam param)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@skip", param.iDisplayStart);
                myParams.Add("@take", param.iDisplayLength);
                myParams.Add("@search_key", param.sSearch);
                var displayResult = await _walletServices.GetDisplayByQuerry("wecharge.USP_GetUsersWallet", myParams).ConfigureAwait(true);
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
        public async Task<IActionResult> UpdateWallet([FromBody] Wallet wallet)
        {
            Wallet _wallet = await _walletServices.GetByID(wallet.ID).ConfigureAwait(false);
            _wallet.Balance = Convert.ToDouble(wallet.Balance);
            var result = _walletServices.UpdateWallet(_wallet);
            return Json(result);
        }
    }
}