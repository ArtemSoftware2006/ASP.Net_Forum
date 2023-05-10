using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Forum.Controllers.Recomendation
{
    public class RecomendationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
