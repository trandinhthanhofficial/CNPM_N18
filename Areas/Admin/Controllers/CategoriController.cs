using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class CategoriController : Controller
    {
        // GET: Admin/Categori
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            List<Category> listCategory = db.Category.ToList();
            return View(listCategory);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCategory(Category model)
        {
            if (string.IsNullOrEmpty(model.Name) == true)
            {
                ModelState.AddModelError("", "Thiếu tên danh mục");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            try
            {
                db.Category.Add(model);
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
            var model = db.Category.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Category model)
        {
            if (string.IsNullOrEmpty(model.Name) == true)
            {
                ModelState.AddModelError("", "Thiếu tên danh mục");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            var updateModel = db.Category.Find(model.ID);
            try
            {
                updateModel.Name = model.Name;
                updateModel.Image = model.Image;
                updateModel.CreatedDate = model.CreatedDate;
                updateModel.CreatedBy = model.CreatedBy;
                updateModel.Status = model.Status;
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
            var model = db.Category.Find(id);
            db.Category.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}