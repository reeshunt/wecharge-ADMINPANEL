using Dapper;
using Microsoft.AspNetCore.Mvc;
using WeCharge.BAL.Services.Implementation;
using WeCharge_AdminPanel.Models.Login;
using WeCharge.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace WeCharge_AdminPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountServices _accountServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(ILogger<HomeController> logger, IAccountServices accountServices, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accountServices = accountServices;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Email", loginViewModel.Email);
                //dynamicParameters.Add("@Password", BCrypt.Net.BCrypt.Verify(loginViewModel.Password,)
                var user = await _accountServices.GetDisplayByQuerry("USP_GET_USER_PROFILE_BY_EMAIL", dynamicParameters);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(loginViewModel);
                }
                else 
                {
                    if (BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.FirstOrDefault().PASSWORD_HASH))
                    {
                        var userClaims = new List<Claim>()
                        {
                            new Claim("UserName", user.FirstOrDefault().FULL_NAME),
                            new Claim(ClaimTypes.Name, user.FirstOrDefault().FULL_NAME),
                            new Claim(ClaimTypes.Email, user.FirstOrDefault().EMAIL),
                            new Claim(ClaimTypes.Role, user.FirstOrDefault().ROLENAME)
                         };

                        var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                        var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                        await HttpContext.SignInAsync(userPrincipal);
                        SetSessionData(user.FirstOrDefault());
                        if (loginViewModel.RememberMe == true)
                        {
                            SetCookie("Username&Password", loginViewModel.Email + "," + loginViewModel.Password, 600);
                        }
                        else
                        {
                            Remove("Username&Password");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(loginViewModel);
                    }
                }
            }
            else
            {
                if (loginViewModel.Email == null) return View(loginViewModel);
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginViewModel);
            }
            return View(loginViewModel);
        }
        /// <summary>
        /// Access Denied default page
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied(string? returnUrl)
        {
            return View(new LoginViewModel());
        }
        [NonAction]
        public bool SetSessionData(WeCharge.Model.DTO.UsersDTO user)
        {
            try
            {
                CookieOptions option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                };
                HttpContext.Session.SetInt32("Email", Convert.ToInt32(user.EMAIL));
                HttpContext.Session.SetInt32("UserID", Convert.ToInt32(user.ID));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(100);

            Response.Cookies.Append(key, value, option);
        }
        /// <summary>
        /// this method is used to remove cookie
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }

        /// <summary>
        /// Users Logout 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {

            Response.Cookies.Delete("UserLoginCookie");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
