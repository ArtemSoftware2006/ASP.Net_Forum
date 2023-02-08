using ASP.Net_Forum.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Forum.Domain.Response;

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
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAll();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
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
