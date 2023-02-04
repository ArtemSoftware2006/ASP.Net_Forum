using ASP.Net_Forum.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using ASP.Net_Forum.Domain.Enum;

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
        public async Task<IActionResult> Index()
        {
            var response = await _userService.GetUser();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }
    }
}
