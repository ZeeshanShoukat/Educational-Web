using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationalWebsite.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signin()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

    }
}