using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Service.Interfaces;

namespace ASP.Net_Forum.Service.Implementations
{
	public class NoteService : INoteService
	{
		readonly INoteRepository _noteRepository;
        private readonly IMarkRepository markRepository;

        public NoteService(INoteRepository noteRepository, IMarkRepository markRepository)
		{
			_noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
			this.markRepository = markRepository;
		}

		public async Task<BaseResponse<bool>> Create(NoteCreateVm noteViewModel)
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
					CategoryId = noteViewModel.CategoryId,
					
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
        public async Task<BaseResponse<IEnumerable<NoteVm>>> GetAll()
        {
            try
            {
				var notes = _noteRepository.GetAll()
					.Select(x => new NoteVm()
					{
						Title = x.Title,
						DateCreated = x.DateCreated,
						ShortDiscription = x.ShortDiscription,
						UserId = x.UserId,
						Category = x.Category.Name,
						Id = x.Id,
						Views = x.Views,
					}) ;
				if (notes.Count() == 0)
				{
					return new BaseResponse<IEnumerable<NoteVm>>
					{
						Description = "Публикаций не найдено.",
						StatusCode = StatusCode.NotFound,
					};
				}
				return new BaseResponse<IEnumerable<NoteVm>>
				{
					Data = notes,
					Description = "OK",
					StatusCode = StatusCode.OK,
				};
            }
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<NoteVm>>
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

		public Task<BaseResponse<bool>> Edit(int id, NoteVm model)
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
					note.Views++;

                    _noteRepository.Update(note);
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
