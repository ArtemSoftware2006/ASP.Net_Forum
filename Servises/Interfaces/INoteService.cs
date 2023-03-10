using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Interfaces
{
	public interface INoteService
	{
		Task<BaseResponse<bool>> Edit(int id, NoteViewModel model);
		Task<BaseResponse<IEnumerable<Note>>> GetAll();
		Task<BaseResponse<Note>> Get(int id);
		Task<BaseResponse<Note>> GetByLogin(string login);
		Task<BaseResponse<Note>> GetByTitle(string title);
		Task<BaseResponse<bool>> Delete(int id);
		Task<BaseResponse<bool>> Create(NoteViewModel userViewModel);
	}
}
