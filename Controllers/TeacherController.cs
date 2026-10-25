using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sarah10415_MVC.Models;

namespace Sarah10415_MVC.Controllers
{
    public class TeacherController : Controller
    {
        SarahDbContext myDB = new SarahDbContext();

        public ActionResult Index()
        {
            List<Teacher> teacherLst = new List<Teacher>();
            teacherLst = (from teacher in myDB.teachers
                       select teacher).ToList();

            return View(teacherLst);
        }

        [HttpGet]
        public ActionResult InsertTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertTeacher(Teacher teacher)
        {
            myDB.teachers.Add(teacher);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers
                   where data.teacherID == id
                   select data).FirstOrDefault();

            return View("Details",obj);
        }

        public ActionResult DeleteTeacher(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers
                   where data.teacherID == id
                   select data).FirstOrDefault();

            myDB.teachers.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}