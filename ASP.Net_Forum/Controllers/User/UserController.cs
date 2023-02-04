using ASP.Net_Forum.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Forum.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserRepository UserRepository;

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            UserRepository.Create(new Domain.Entity.User() { Id = 0, Age = 10, Login = "Root", Password = "1232", Email = "12@wer" });

            return View(UserRepository.GetAll().ToList());
        }
    }
}
