using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            List<Product> listProduct = db.Product.ToList();
            return View(listProduct);
        }
        public ActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProduct(Product model)
        {
            if (string.IsNullOrEmpty(model.Title) == true)
            {
                ModelState.AddModelError("", "Thiếu tên sản phẩm");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Description) == true)
            {
                ModelState.AddModelError("", "Thiếu mô tả sản phẩm");
                return View(model);
            }
            if (model.Price < 0)
            {
                ModelState.AddModelError("", "Giá bán không hợp lệ");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            try
            {
                db.Product.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

        }
        public ActionResult CapNhat(int id)
        {
            Manager_cafeEntities db = new Manager_cafeEntities();
            var model = db.Product.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Product model)
        {
            if (string.IsNullOrEmpty(model.Title) == true)
            {
                ModelState.AddModelError("", "Thiếu tên sản phẩm");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Description) == true)
            {
                ModelState.AddModelError("", "Thiếu nội dung sản phẩm");
                return View(model);
            }
            if (model.Price < 0)
            {
                ModelState.AddModelError("", "Giá bán không hợp lệ");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            var updateModel = db.Product.Find(model.ID);
            try
            {
                updateModel.Title = model.Title;
                updateModel.Description = model.Description;
                updateModel.Imager = model.Imager;
                updateModel.Price = model.Price;
                updateModel.ID_category = model.ID_category;
                updateModel.Status = model.Status;
                updateModel.Unit = model.Unit;
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
            var model = db.Product.Find(id);
            db.Product.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}