
using Cafe_manager.Areas.Admin.Models;
using Cafe_manager.Common;
using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public User getItem(string email)
        {
            return db.User.FirstOrDefault(x => x.Email == email);
        }
        public List<User> getList()
        {
            return db.User.ToList();
        }
        public int Login(string email, string pass)
        {
            var user = db.User.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return -2;
            }
            else
            {
                if(user.Status==false)
                {
                    return 0;
                }
                else
                {
                    if (user.Password == pass)
                    {
                        return 1;//Đăng nhập thành công
                    }
                    else
                    {
                        return -1;//Sai mk
                    }
                }
            }
        }
        public ActionResult LoginModelAction(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginController();
                var result = dao.Login(model.Email, Encrytor.GetHash(model.Password));
                if (result == 1)
                {
                    var user = dao.getItem(model.Email);
                    var session = new Userlogin();
                    session.Email = user.Email;
                    session.ID = user.ID;
                    session.UserName = user.UserName;
                    session.FullName = user.FullName;
                    Session.Add(Cafe_manager_fun.USER_SESSION, session);
                    return RedirectToAction("Index", "Home");
                }
                else if(result==0)
                {
                    ModelState.AddModelError("", "Tài khoản chưa kích hoạt vui lòng liên hệ admin");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Email không tồn tại.");
                }
            }
            return View("Index");
        }
    }
}