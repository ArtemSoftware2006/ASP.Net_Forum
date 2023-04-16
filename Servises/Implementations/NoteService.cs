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

		public async Task<BaseResponse<bool>> Create(NoteCreateViewModel noteViewModel)
		{
			var response = new BaseResponse<bool>();

			try
			{
				var note = new Note
				{
					Body = noteViewModel.Body,
					Title = noteViewModel.Title,
					ShortDiscription = noteViewModel.ShortDiscription,
					DateCreated = DateTime.Now,
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
        public async Task<BaseResponse<IEnumerable<NoteViewModel>>> GetAll()
        {
            try
            {
				var notes = _noteRepository.GetAll()
					.Select(x => new NoteViewModel()
					{
						Title = x.Title,
						DateCreated = x.DateCreated,
						ShortDiscription = x.ShortDiscription,
						UserId = x.UserId,
						Id = x.Id
					}) ;
				if (notes.Count() == 0)
				{
					return new BaseResponse<IEnumerable<NoteViewModel>>
					{
						Description = "Публикаций не найдено.",
						StatusCode = StatusCode.NotFound,
					};
				}
				return new BaseResponse<IEnumerable<NoteViewModel>>
				{
					Data = notes,
					Description = "OK",
					StatusCode = StatusCode.OK,
				};
            }
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<NoteViewModel>>
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

		public async Task<BaseResponse<Note>> Get(int id)
		{
			try
			{
				var note = await _noteRepository.Get(id);

				if (note != null)
				{
					return new BaseResponse<Note>
					{
						Data = note,
						StatusCode = StatusCode.OK,
						Description = "OK",
					};
				}
				return new BaseResponse<Note>
				{
					StatusCode = StatusCode.InternalServerError,
					Description = "Нет статьи с таким индексом",
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Note>
				{
					StatusCode = StatusCode.InternalServerError,
					Description = ex.Message,
				};
			}
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
