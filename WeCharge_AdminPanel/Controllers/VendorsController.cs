using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge_AdminPanel.Models;
using System.Linq;
using AutoMapper;
using WeCharge.Model;
using Microsoft.DotNet.MSIdentity.Shared;
using WeCharge.Model.DTO;

namespace WeCharge_AdminPanel.Controllers
{
    public class VendorsController : Controller
    {
        private readonly ILogger<VendorsController> _logger;
        private readonly IAccountServices _accountServices;
        private readonly IMapper _mapper;

        public VendorsController(ILogger<VendorsController> logger, IMapper mapper, IAccountServices accountServices)
        {
            _mapper = mapper;
            _accountServices = accountServices;
            _logger = logger;
        }

        /// <summary>
        /// Get List of vendors
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            ViewBag.VendorName = await _accountServices.GetDisplayByQuerry("wecharge.USP_Get_ActiveVendors", null);
            return View();
        }

        /// <summary>
        /// Get the UI of ADD
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Get list of vendors by JSON
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetAllVendors(JqueryDatatableParam param)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@skip", param.iDisplayStart);
                myParams.Add("@take", param.iDisplayLength);
                myParams.Add("@search_key", param.sSearch);
                myParams.Add("@userName", param.UserType);
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

        /// <summary>
        /// Add Vendors.
        /// </summary>
        /// <param name="usersViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(UsersViewModel usersViewModel)
        {
            try
            {
                var proMap = _mapper.Map<Users>(usersViewModel);
                proMap.CREATED_DATE = DateTime.Now;
                proMap.MODOFIED_DATE = DateTime.Now;
                proMap.IMAGE_PATH = "http://103.205.66.213:3000/image/avatar1.jpg";
                proMap.IS_ACTIVE = true;
                proMap.ROLE_ID = 3;
                proMap.PASSWORD_HASH = "$2b$10$Lzx9ZXkz6t1I2ZySz.Jf/uOgnxPEu386tx96bZ9XRqkVHijcksjJS";
                await _accountServices.AddVendor(proMap);
                return RedirectToAction("Add");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Edit vendors by ID  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var getUserData = await _accountServices.GetById(id);
                if (getUserData != null)
                {
                    var proMap = _mapper.Map<UsersViewModel>(getUserData);
                   // return Redirect(Url.Action("Edit", "Vendors"));
                    return View(proMap);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update the vendors details
        /// </summary>
        /// <param name="usersViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(UsersViewModel usersViewModel)
        {
            try
            {
                var getUserData = await _accountServices.GetById(usersViewModel.Id);
                if (getUserData != null)
                {
                    getUserData.EMAIL = usersViewModel.EMAIL;
                    getUserData.FULL_NAME = usersViewModel.FULL_NAME;
                    getUserData.MOBILE_NO = usersViewModel.MOBILE_NO; ;
                    getUserData.MODOFIED_DATE = DateTime.Now;
                    getUserData.IMAGE_PATH = "http://103.205.66.213:3000/image/avatar1.jpg";
                    var status = await _accountServices.UpdateVendor(getUserData);
                    if (status)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Edit", usersViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete the Vendor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var getUserData = await _accountServices.GetById(Id);
                if (getUserData != null)
                {
                    getUserData.IS_ACTIVE = false;
                    var status = await _accountServices.UpdateVendor(getUserData);
                    if (status)
                    {
                        return Json(true);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
