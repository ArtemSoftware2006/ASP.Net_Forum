using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

namespace ASP.Net_Forum.Controllers.Recomendation
{
    public class RecomendationController : Controller
    {
        private readonly IRecomendationService recomendationService;
        private readonly IUserService userService;

        public RecomendationController(IRecomendationService recomendationService, IUserService userService)
        {
            this.recomendationService = recomendationService;
            this.userService = userService;
        }

        public async Task<IActionResult> Recomendation()
        {
            var userId = await userService.GetByLogin(HttpContext.User.Identity.Name);

            var response = await recomendationService.Get(userId.Data.Id);

            return View(response.Data);
        }
    }
}
