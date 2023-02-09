using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Enum;
using ASP.Net_Forum.Domain.Helpers;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Domain.ViewModels.User;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Claims;
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

        public async Task<BaseResponse<IEnumerable<User>>> GetAll()
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
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[GetUsers] : {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<User>> Get(int id)
        {
            try
            {
                var baseResponse = new BaseResponse<User>();
                var user = await _userRepository.Get(id);
                if (user != null)
                {
                    baseResponse.StatusCode = StatusCode.NotFound;
                    baseResponse.Description = "User not found";
                }
                else
                {
                    baseResponse.Data = user; 
                    baseResponse.StatusCode = StatusCode.OK;
                    baseResponse.Description = "OK";
                }
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[Get(User)] : {ex.Message})"
                };
            }
        }
        public async Task<BaseResponse<User>> GetByLogin(string login)
        {
            try
            {
                var baseResponse = new BaseResponse<User>();
                var user = await _userRepository.GetByLogin(login);
                if (user != null)
                {
                    baseResponse.StatusCode = StatusCode.NotFound;
                    baseResponse.Description = "User not found";
                }
                else
                {
                    baseResponse.Data = user;
                    baseResponse.StatusCode = StatusCode.OK;
                    baseResponse.Description = "OK";
                }
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[GetByLogin(User)] : {ex.Message})"
                };
            }
        }
        public async Task<BaseResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _userRepository.Get(id);

                if (user == null)
                {
                    baseResponse.StatusCode = StatusCode.NotFound;
                    baseResponse.Description = "User not found";
                }
                else
                {
                    baseResponse.Data = true;
                    baseResponse.StatusCode = StatusCode.OK;
                    baseResponse.Description = "OK";

                    await _userRepository.Delete(user);
                }
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[Delete(User)] : {ex.Message})"
                };
            }
        }
        public async Task<BaseResponse<bool>> Create(UserViewModel userViewModel)
        {
            var baseRespnse = new BaseResponse<bool>();

            try
            {
                var user = new User()
                {
                    Age = userViewModel.Age,
                    Email = userViewModel.Email,
                    CardNumber = userViewModel.CardNumber,
                    PhoneNumber = userViewModel.PhoneNumber,
                    Login = userViewModel.Login,
                    Password = userViewModel.Password,
                };

                await _userRepository.Create(user);

                baseRespnse.Data = true;
                baseRespnse.Description = "OK";
                baseRespnse.StatusCode = StatusCode.OK;

                return baseRespnse;
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
        public async Task<BaseResponse<bool>> Edit(int id, UserViewModel model)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _userRepository.Get(id);
                if (user != null)
                {
                    baseResponse.StatusCode = StatusCode.NotFound;
                    baseResponse.Description = "User not found";
                }
                else
                {
                    user.Login = model.Login;
                    user.Password = model.Password;
                    user.Age = model.Age;
                    user.Email = model.Email;
                    user.CardNumber = model.CardNumber;
                    user.PhoneNumber = model.PhoneNumber;

                    await _userRepository.Update(user);
                }

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[Edit(User)] : {ex.Message})"
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Registr(RegistrViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefault(x => x.Login == model.Login);

                if(user != null)
                {
                    return new BaseResponse<ClaimsIdentity>
                    {
                        StatusCode = StatusCode.NotFound,
                        Description = "Пользователь с таким именем уже существует."
                    };
                }
                else
                {
                    user = new User()
                    {
                        Login = model.Login,
                        Password = HashPasswordHelper.HashPassword(model.Password),
                        Age = model.Age,
                        Email = model.Email,
                        CardNumber = model.CardNumber,
                        PhoneNumber = model.PhoneNumber,

                        Role = Role.User,
                    };


                    var result = Authenticate(user);

                    _userRepository.Create(user);

                    return new BaseResponse<ClaimsIdentity>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "OK",
                        Data = result,
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[Registr(User)] : {ex.Message})"
                };
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
