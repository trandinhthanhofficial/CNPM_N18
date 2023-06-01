using Cafe_manager.Areas.Admin.Models;
using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            List<Order> listOrder = db.Order.ToList();
            return View(listOrder);
        }
        public ActionResult Pay(int id)
        {
            Order order = db.Order.Where(p => p.ID == id).FirstOrDefault();
            return View("Pay", order);
        }
    }
}