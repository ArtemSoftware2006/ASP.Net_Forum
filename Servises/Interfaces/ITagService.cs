using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.Note;
using ASP.Net_Forum.Domain.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Interfaces
{
	public interface ITagService
	{
		Task<BaseResponse<bool>> Edit(int id, Tag model);
		Task<BaseResponse<IEnumerable<Tag>>> GetAllTags();
		Task<BaseResponse<Tag>> Get(int id);
		Task<BaseResponse<bool>> Delete(int id);
		Task<BaseResponse<bool>> Create(TagCreateViewModel model);
	}
}
