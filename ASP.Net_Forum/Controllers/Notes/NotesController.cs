using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Forum.Controllers.Notes
{
    public class NotesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {

            return View();
        }
    }
}
