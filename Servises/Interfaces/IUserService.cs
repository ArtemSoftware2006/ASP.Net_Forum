using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<bool>> Edit(int id, UserViewModel model);
        Task<BaseResponse<IEnumerable<User>>> GetAll();
        Task<BaseResponse<User>> Get(int id);
        Task<BaseResponse<User>> GetByLogin(string login);
        Task<BaseResponse<bool>> Delete(int id);
        Task<BaseResponse<bool>> Create(UserViewModel userViewModel);
        Task<BaseResponse<ClaimsIdentity>> Registr(RegistrViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
