using EducationalWebsite.Models;
using EducationalWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EducationalWebsite.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext db;
        public DepartmentController()
        {
            db = new ApplicationDbContext();

        }
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        async public Task<ActionResult> DepartmentDetail()
        {
            return View(await db.Departments.ToListAsync());
        }
        public ActionResult AddDepartment()
        {
            return View();
        }


    }
}