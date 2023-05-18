using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Service.Interfaces;

namespace ASP.Net_Forum.Service.Implementations
{
	public class NoteTagsService : INoteTagsService
	{
		public Task<BaseResponse<bool>> Create(NoteTags model)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> Edit(int id, NoteTags model)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<NoteTags>> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<IEnumerable<NoteTags>>> GetAllTags()
		{
			throw new NotImplementedException();
		}
	}
}
