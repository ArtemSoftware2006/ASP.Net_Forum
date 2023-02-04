using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Response;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<IEnumerable<User>>> GetUser()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var users = await _userRepository.GetAll();
                if (users.Count() == 0)
                {
                    baseResponse.StatusCode = StatusCode.NotFound;
                    baseResponse.Description = "Найдено 0 пользователей";
                    return baseResponse;
                }
                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = $"[GetUsers] : {ex.Message}"
                };
            }
        }
    }
}
