using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Forum.DAL.Interfaces;
using Service.Interfaces;
using Service.Implementations;

namespace ASP.Net_Forum.Controllers.Notes
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IUserService _userService;
        public NotesController(INoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
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
        public async Task<IActionResult> Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(NoteCreateViewModel noteModel)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.GetByLogin(HttpContext.User.Identity.Name);

                noteModel.UserId = userId.Data.Id;

                 var response = await _noteService.Create(noteModel);

                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", response.Description);
                }
            }
            return View(noteModel);
        }

    }
}
