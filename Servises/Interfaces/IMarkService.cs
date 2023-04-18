using ASP.Net_Forum.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Interfaces
{
	public interface IMarkService
	{
		Task<BaseResponse<bool>> ClickLike(int UserId, int NoteId);
	}
}
