using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationalWebsite.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseDetail()
        {
            return View();
        }
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCoursee()
        {
            return View();
        }
        public ActionResult DeleteCourse()
        {
            return View();
        }
        public ActionResult CourseInformation()
        {
            return View();
        }

    }
}