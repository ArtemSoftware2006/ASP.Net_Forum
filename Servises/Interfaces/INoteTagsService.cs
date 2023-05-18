using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Interfaces
{
	public interface INoteTagsService
	{
		Task<BaseResponse<bool>> Edit(int id, NoteTags model);
		Task<BaseResponse<IEnumerable<NoteTags>>> GetAllTags();
		Task<BaseResponse<NoteTags>> Get(int id);
		Task<BaseResponse<bool>> Delete(int id);
		Task<BaseResponse<bool>> Create(NoteTags model);
	}
}
