using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sarah10415_MVC.Models;

namespace Sarah10415_MVC.Controllers
{
    public class StudentController : Controller
    {
        SarahDbContext myDB = new SarahDbContext();

        public ActionResult Index()
        {
            List<Student> studentLst = new List<Student>();
            studentLst = (from Student in myDB.students
                       select Student).ToList();

            return View(studentLst);
        }

        [HttpGet]
        public ActionResult InsertStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertStudent(Student student)
        {
            myDB.students.Add(student);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
            Student obj = new Student();
            obj = (from data in myDB.students
                   where data.studentID == id
                   select data).FirstOrDefault();

            return View("SDetails", obj);
        }

        public ActionResult DeleteStudent(int id)
        {
            Student obj = new Student();
            obj = (from data in myDB.students
                   where data.studentID == id
                   select data).FirstOrDefault();

            myDB.students.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
   