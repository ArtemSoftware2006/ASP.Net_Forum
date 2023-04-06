using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Domain.ViewModels.Tag;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Forum.Controllers.Tag
{
    public class TagController : Controller
    {
        private ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _tagService.GetAllTags();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("AdminMenu",response.Data.ToList());
            }
            else if (response.StatusCode == Domain.Enum.StatusCode.NotFound)
            {
                return View(new List<TagCreateViewModel>());
            }

            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Create(TagCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _tagService.Create(model);

                if (response.StatusCode == Domain.Enum.StatusCode.OK) 
                {
                    return View(response.Data);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }

            return View(model);
        }

    }
}
