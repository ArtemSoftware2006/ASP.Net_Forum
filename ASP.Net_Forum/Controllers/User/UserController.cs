using ASP.Net_Forum.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Forum.Domain.Response;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ASP.Net_Forum.Controllers.User
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Registr() => View();

        [HttpPost]
        public async Task<IActionResult> Registr(RegistrViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.Registr(model);

                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", response.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.Login(model);

                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                }
                else
                {
                    ModelState.AddModelError("", response.Description);
                }
            }
			return Redirect("~/Home/Index");
		}

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Profil()
        {
            var result = await _userService.GetByLogin(User.Identity.Name);

            if (result.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(result.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = await _userService.Get(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAll();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userService.Delete(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }



        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _userService.Get(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }



        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Save(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                BaseResponse<bool> response = new BaseResponse<bool>();
                if (model.Id == 0)
                {
                    response = await _userService.Create(model);
                }
                else
                {
                    response = await _userService.Edit(model.Id, model);
                }

                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View(response.Data);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            return RedirectToAction("Error");
        }
    }
}
