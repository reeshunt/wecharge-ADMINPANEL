using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge.BAL.Services.Interface;
using WeCharge.Model;
using WeCharge_AdminPanel.Models;

namespace WeCharge_AdminPanel.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly ILogger<TimeSlotController> _logger;
        private readonly ITimeSlotServices _timeSlotServices;
        private readonly IMapper _mapper;
        public TimeSlotController(ILogger<TimeSlotController> logger, IMapper mapper, ITimeSlotServices timeSlotServices)
        {
            _mapper = mapper;
            _timeSlotServices = timeSlotServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateTimeSlot(TimeSlotViewModel timeSlotViewModel)
        {
            try
            {
                timeSlotViewModel.CREATED_BY = "SUPERADMIN";
                timeSlotViewModel.IS_ACTIVE = true;
                timeSlotViewModel.CREATED_DATE = DateTime.Now;
                timeSlotViewModel.MODOFIED_DATE = DateTime.Now;
                var proMap = _mapper.Map<TimeSlot>(timeSlotViewModel);
                await _timeSlotServices.Add(proMap);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var timeslotContent = await _timeSlotServices.GetById(id);
                var proMap = _mapper.Map<TimeSlotViewModel>(timeslotContent);
                return View(proMap);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<IActionResult> UpdateTimeSlot(TimeSlotViewModel timeSlotViewModel)
        {
            try
            {
                var getTimeSlot = await _timeSlotServices.GetById(timeSlotViewModel.ID);
                getTimeSlot.MODIFIED_BY = "SUPERADMIN";
                getTimeSlot.MODOFIED_DATE = DateTime.Now;
                getTimeSlot.TIME_SLOT_TO = timeSlotViewModel.TIME_SLOT_TO;
                getTimeSlot.TIME_SLOT_FROM = timeSlotViewModel.TIME_SLOT_FROM;
                await _timeSlotServices.Update(getTimeSlot);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IActionResult> GetAllTimeSlot(JqueryDatatableParam param)
        {
            try
            {
                var myParams = new DynamicParameters();
                myParams.Add("@skip", param.iDisplayStart);
                myParams.Add("@take", param.iDisplayLength);
                myParams.Add("@search_key", param.sSearch);
                var displayResult = await _timeSlotServices.GetDisplayByQuerry("wecharge.USP_GetTIMESLOT_Datatable", myParams).ConfigureAwait(true);
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

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var getUserData = await _timeSlotServices.GetById(Id);
                if (getUserData != null)
                {
                    getUserData.IS_ACTIVE = false;
                    var status = await _timeSlotServices.Delete(getUserData);
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
