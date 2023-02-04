using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
         Task<BaseResponse<IEnumerable<User>>> GetUser();
    }
}
