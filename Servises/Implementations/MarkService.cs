using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Implementations
{
	public class MarkService : IMarkService
	{
		private readonly IMarkRepository markRepository;
		private readonly INoteRepository noteRepository;

		public MarkService(IMarkRepository markRepository, INoteRepository noteRepository )
		{
			this.markRepository = markRepository;
			this.noteRepository = noteRepository;
		}

		public async Task<BaseResponse<bool>> ClickLike(int UserId, int NoteId)
		{
			try
			{
				var mark = markRepository.GetAll().FirstOrDefault(x => x.NoteId == NoteId && x.UserId == UserId);

                var note = await noteRepository.Get(NoteId);

                if (mark == null)
				{
                    mark = new UserMark()
					{
						UserId = UserId,
						NoteId = NoteId,
						Mark = (int)Mark.Like
					};

					await markRepository.Create(mark);

					note.ValueMark++;
					await noteRepository.Update(note);

                    return new BaseResponse<bool>() 
					{
						Data = true,
						Description = "Ok",
						StatusCode = StatusCode.OK,
					};
				}

				if (mark.Mark == (int)Mark.Like)
				{
					mark.Mark = (int)Mark.None;

					await markRepository.Update(mark);

                    note.ValueMark--;
                    await noteRepository.Update(note);

                    return new BaseResponse<bool> 
					{ 
						Data = false, 
						Description = "Ok",
						StatusCode = StatusCode.OK
					};
				}
				else
				{

				}

				mark.Mark = (int)Mark.Like;

				await markRepository.Update(mark);

                note.ValueMark++;
                await noteRepository.Update(note);

                return new BaseResponse<bool>
				{
					Data = true,
					Description = "Ok",
					StatusCode = StatusCode.OK
				};

			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					Description = ex.Message,
					StatusCode = Domain.Enum.StatusCode.InternalServerError,
				};
			}
		}
	}
}
