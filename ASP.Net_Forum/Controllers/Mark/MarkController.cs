using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace ASP.Net_Forum.Controllers.Mark
{
	public class MarkController : Controller
	{
		private readonly IMarkService markService;
		private readonly IUserService userService;
		public MarkController(IMarkService markService, IUserService userService)
		{
			this.markService = markService;
			this.userService = userService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> ClickLike(int NoteId)
		{
			if (ModelState.IsValid)
			{
				var response = await markService.ClickLike(userService.GetByLogin(HttpContext.User.Identity.Name).Result.Data.Id, NoteId);

				if (response.StatusCode == Domain.Enum.StatusCode.OK)
				{
					return Json(response.Data);
				}

				return StatusCode(500,response.Description);
				
			}
			return BadRequest("Модель не валидна");
		}
	}
}
