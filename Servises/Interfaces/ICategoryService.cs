using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseResponse<bool>> Edit(Category model);
        Task<BaseResponse<IEnumerable<Category>>> GetAll();
        Task<BaseResponse<Category>> Get(int id);
        Task<BaseResponse<bool>> Delete(int id);
        Task<BaseResponse<bool>> Create(Category userViewModel);
    }
}
