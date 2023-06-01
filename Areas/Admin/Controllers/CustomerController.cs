using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            List<Customer> listCustomer = db.Customer.ToList();
            return View(listCustomer);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCustomer(Customer model)
        {
            if (string.IsNullOrEmpty(model.Fullname) == true)
            {
                ModelState.AddModelError("", "Thiếu tên khách hàng");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Email) == true)
            {
                ModelState.AddModelError("", "Thiếu Email khách hàng");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            try
            {
                db.Customer.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

        }
        public ActionResult Xoa(int id)
        {
            Manager_cafeEntities db = new Manager_cafeEntities();
            var model = db.Customer.Find(id);
            db.Customer.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}