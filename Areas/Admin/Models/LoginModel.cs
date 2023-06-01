using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cafe_manager.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
    }

}