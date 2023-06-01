using Cafe_manager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafe_manager.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        Manager_cafeEntities db = new Manager_cafeEntities();
        public ActionResult Index()
        {
            List<Staff> listStaff = db.Staff.ToList();
            return View(listStaff);
        }
        public ActionResult AddStaff()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddStaff(Staff model)
        {
            if (string.IsNullOrEmpty(model.Fullname) == true)
            {
                ModelState.AddModelError("", "Thiếu tên nhân viên");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Phonenumber) == true)
            {
                ModelState.AddModelError("", "Thiếu số điện thoại");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            try
            {
                db.Staff.Add(model);
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
            var model = db.Staff.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Staff model)
        {
            if (string.IsNullOrEmpty(model.Fullname) == true)
            {
                ModelState.AddModelError("", "Thiếu tên nhân viên");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Phonenumber) == true)
            {
                ModelState.AddModelError("", "Thiếu số điện thoại");
                return View(model);
            }
            Manager_cafeEntities db = new Manager_cafeEntities();
            var updateModel = db.Staff.Find(model.ID);
            try
            {
                updateModel.Fullname = model.Fullname;
                updateModel.Email = model.Email;
                updateModel.Imagesaff = model.Imagesaff;
                updateModel.Gender = model.Gender;
                updateModel.Position = model.Position;
                updateModel.Address = model.Address;
                updateModel.Birthday = model.Birthday;
                updateModel.Phonenumber = model.Phonenumber;
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
            var model = db.Staff.Find(id);
            db.Staff.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult Detail(int id)
        {
            Staff staff = db.Staff.Where(p => p.ID == id).FirstOrDefault();
            return PartialView("_DetailStaffPartialView", staff);
        }
    }
}