using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Entity;

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
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            else if (response.StatusCode == Domain.Enum.StatusCode.NotFound)
            {
                return View(new List<NoteViewModel>());
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> CreateNote() => View();
  //      [HttpPost]
		//public async Task<IActionResult> CreateNote()
  //      {
            
  //      }

	}
}
