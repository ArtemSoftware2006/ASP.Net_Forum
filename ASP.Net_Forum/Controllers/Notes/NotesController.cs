using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Forum.Controllers.Notes
{
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            return View();
        }
    }
}
