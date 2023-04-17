using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Forum.DAL.Interfaces;
using Service.Interfaces;
using Service.Implementations;
using ASP.Net_Forum.DAL.Migrations;

namespace ASP.Net_Forum.Controllers.Notes
{
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        public NotesController(INoteService noteService, IUserService userService, ICategoryService categoryService)
        {
            _noteService = noteService;
            _userService = userService;
            _categoryService = categoryService;
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
        [HttpPost]
		public async Task<IActionResult> Show(int noteId)
        {
            if (ModelState.IsValid)
            {
                var response = await _noteService.Get(noteId);

				if (response.StatusCode == Domain.Enum.StatusCode.OK)
				{
					return View(response.Data);
				}
				else
				{
					ModelState.AddModelError("", response.Description);
				}
			}
			return View();
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create() => View(ViewBag.Categories = _categoryService.GetAll().Result.Data.ToList());
        [HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(NoteCreateVm noteModel)
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
