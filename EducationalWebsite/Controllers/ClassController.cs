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
    public class ClassController : Controller
    {
        ApplicationDbContext db;
        public ClassController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult AddClass()
        //{
           
        //    return View();
        //}
        //[HttpPost]
        //async public Task<ActionResult> AddClass(Class cls)
        //{
        //    db.Classes.Add(cls);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("AddClassDetail",cls);
        //}
        async public Task<ActionResult> AddClassDetail()
        {
            var ClassList = await db.Classes.ToListAsync();
            var SectionList = await db.ClassSections.ToListAsync();
            var TeachersList = await db.Teachers.Include("Gender").ToListAsync();

            var ClsVm = new ClassVm()
            {
                Classes=ClassList,
                ClassSections = SectionList,
                Teachers = TeachersList
                
            };
            return View(ClsVm);
        }
        [HttpPost]
        async public Task<ActionResult> AddClassDetail(ClassVm cls)
        {
            if (cls.classDetail.Id == 0)
            {
                db.ClassDetails.Add(cls.classDetail);
                await db.SaveChangesAsync();
            }
            else {
                var cd = db.ClassDetails.SingleOrDefault(m => m.Id == cls.classDetail.Id);
                cd.ClassId = cls.classDetail.ClassId;
                cd.ClassSctionId = cls.classDetail.ClassSctionId;
                cd.TeacherId = cls.classDetail.TeacherId;
                await db.SaveChangesAsync();
            }
           
            return RedirectToAction("ClassesDetail");
        }
        async public Task<ActionResult> ClassesDetail()
        {
            //var Strength = db.Students.Include("Class").Include("ClassSection").GroupBy(x => x.Class.Name).Count(Dis);
            //ViewBag.StdCount =Strength;
            //var data = await db.ClassDetails.Include("Class").Include("ClassSection").ToListAsync();
            var data = await db.ClassDetails.Include("Class").Include("ClassSection").Include("Teacher").ToListAsync();
            return View(data);
        }
         async public Task<ActionResult> Edit(int id)
        {
            var data = db.ClassDetails.Include("class").Include("Teacher").Include("ClassSection").SingleOrDefault(m => m.Id == id);
            var ClassList = await db.Classes.ToListAsync();
            var SectionList = await db.ClassSections.ToListAsync();
            var TeachersList = await db.Teachers.Include("Gender").ToListAsync();
            var ClassVm = new ClassVm() {
                classDetail = data,
                Classes=ClassList,
                ClassSections=SectionList,
                Teachers=TeachersList
            };
            return View("AddClassDetail", ClassVm);
        }
        public ActionResult Delete(int id)
        {
            var data = db.ClassDetails.SingleOrDefault(m => m.Id == id);
            db.ClassDetails.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ClassesDetail");
        }

    }
}