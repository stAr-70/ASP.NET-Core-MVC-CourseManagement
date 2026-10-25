using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sarah10415_MVC.Models;

namespace Sarah10415_MVC.Controllers
{
    public class CourseController : Controller
    {
        SarahDbContext myDB = new SarahDbContext();
        public ActionResult Index()
        {

            List<Course> courseLst = new List<Course>();
            courseLst = (from course in myDB.courses
                         select course).ToList();

            return View(courseLst);
        }

        public ActionResult GetDetails(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseID == id
                   select course).FirstOrDefault();
           
            return View("CourseDetails",obj);
        }

        [HttpGet]

        public ActionResult InsertCourse()
        {
            return View();
        }

        [HttpPost]

        public ActionResult InsertCourse(Course course)
        {
            myDB.courses.Add(course);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseID == id
                   select course).FirstOrDefault();

            myDB.courses.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult UpdateCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses
                   where course.courseID == id
                   select course).FirstOrDefault();

            return View("UpdateCourse", obj);
        }
        

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
             
            var obj = (from c in myDB.courses
                       where c.courseID == course.courseID
                       select c).FirstOrDefault();

            if (obj != null)
            {
                
                obj.courseName = course.courseName;
                obj.isAvailable = course.isAvailable;

                myDB.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}