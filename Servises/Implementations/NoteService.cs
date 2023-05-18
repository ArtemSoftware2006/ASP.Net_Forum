using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.DAL.Repositories;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Implementations
{
	public class NoteService : INoteService
	{
		readonly INoteRepository _noteRepository;

		public NoteService(INoteRepository noteRepository)
		{
			_noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
		}

		public async Task<BaseResponse<bool>> Create(NoteViewModel noteViewModel)
		{
			var response = new BaseResponse<bool>();

			try
			{
				var note = new Note
				{
					Body = noteViewModel.Body,
					Title = noteViewModel.Title,
					ShortDiscription = noteViewModel.ShortDiscription,
					DateCreated = DateTime.UtcNow,
					UserId = noteViewModel.UserId,
					
				};

				await _noteRepository.Create(note);

				response.Data = true;
				response.Description = "OK";
				response.StatusCode = Domain.Enum.StatusCode.OK;

				return response;
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					StatusCode = StatusCode.InternalServerError,
					Description = $"[Create(User)] : {ex.Message})"
				};
			}		
		}

		public Task<BaseResponse<bool>> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> Edit(int id, NoteViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<Note>> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<IEnumerable<Note>>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<Note>> GetByLogin(string login)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<Note>> GetByTitle(string title)
		{
			throw new NotImplementedException();
		}
	}
}
