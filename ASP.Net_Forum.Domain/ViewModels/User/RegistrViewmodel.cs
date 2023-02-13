using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.ViewModels.User
{
    public class RegistrViewModel
    {
        [MaxLength(100, ErrorMessage = "Логин должен содержать менее 100 символов")]
        [Required(ErrorMessage = "Укажите логин")]
        [MinLength(3,ErrorMessage = "Логин дожен содержать не менее 3 символов")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Пароль должен содержать менее 100 символов")]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен содержать не менее 8 символов")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        public string ConfimPassword { get; set; }
        public int Age { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        public string Email { get; set; }
        [Column("Phone_number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
