using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuntificationMetanit.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]

        [EmailAddress(ErrorMessage = "Указан неверный email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}
