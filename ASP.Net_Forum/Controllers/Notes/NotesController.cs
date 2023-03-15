using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASP.Net_Forum.Domain.Enum;

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
            var response = await _noteService.GetAll();
            if (response.StatusCode != Domain.Enum.StatusCode.InternalServerError)
            {
                return View(response);
            }
            return RedirectToAction("Error");
        }
    }
}
