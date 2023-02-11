using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.ViewModels.User
{
    public class LoginViewModel
    {
        [MaxLength(100, ErrorMessage = "Логин должен содержать менее 100 символов")]
        [Required(ErrorMessage = "Укажите логин")]
        [MinLength(3, ErrorMessage = "Логин дожен содержать не менее 3 символов")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Пароль должен содержать менее 100 символов")]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен содержать не менее 8 символов")]
        public string Password { get; set; }
    }
}
