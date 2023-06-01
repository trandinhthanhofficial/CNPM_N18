using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: Admin/OrderDetail
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            List<OrderDetail> listOrderDetail = db.OrderDetail.ToList();
            return View(listOrderDetail);
        }
    }
}