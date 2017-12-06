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
    public class SubjectController : Controller
    {
        ApplicationDbContext db;
        // GET: Subject
        public SubjectController()
        {
            db = new ApplicationDbContext();       
        }
        public ActionResult Index()
        {
            return View();
        }
       async public Task<ActionResult> SubjectDetail()
        {
            var data = await db.SubjectDetails.Include(m=>m.Subject).Include(m=>m.Teacher).Include(m=>m.Class).ToListAsync();
            return View(data);
        }
        async public Task<ActionResult> AddSubjectDetail()
        {
            var classlist = await db.Classes.ToListAsync();
            var subjectlist = await db.Subjects.ToListAsync();
            var teacherlist = await db.Teachers.ToListAsync();
            var data = new SubjectVm
            {
                Classes=classlist,
                Subjects=subjectlist,
                Teachers=teacherlist
            };

            return View(data);
        }
        [HttpPost]
        async public Task<ActionResult> AddSubjectDetail(SubjectVm Subj)
        {
            if (Subj.subjectDetails.Id==0)
            {
                db.SubjectDetails.Add(Subj.subjectDetails);
                await db.SaveChangesAsync();
            }
            else
            {
                var record =await db.SubjectDetails.Include("Class").Include("Subject").Include("Teacher").SingleOrDefaultAsync(m=>m.Id==Subj.subjectDetails.Id);
                record.SubjectId = Subj.subjectDetails.SubjectId;
                record.ClassId = Subj.subjectDetails.ClassId;
                record.TeacherId = Subj.subjectDetails.TeacherId;
              await  db.SaveChangesAsync();
            }
            return RedirectToAction("SubjectDetail");
        }
        async public Task<ActionResult> EditSubjectDetail(int id)
        {
            var sd = await db.SubjectDetails.Include(m => m.Subject).Include(m => m.Class).Include(m => m.Teacher).SingleOrDefaultAsync(m=>m.Id==id);
            var classlist = await db.Classes.ToListAsync();
            var subjectlist = await db.Subjects.ToListAsync();
            var teacherlist = await db.Teachers.ToListAsync();
            var data = new SubjectVm
            {
                subjectDetails = sd,
                Classes = classlist,
                Subjects = subjectlist,
                Teachers = teacherlist
            };

            return View("AddSubjectDetail",data);
        }
        async public Task<ActionResult> RemoveSubjectDetail(int id)
        {
            var cd = await db.SubjectDetails.Include(m => m.Subject).Include(m => m.Class).Include(m => m.Teacher).SingleOrDefaultAsync(m => m.Id == id);
            db.SubjectDetails.Remove(cd);
            await db.SaveChangesAsync();
            return RedirectToAction("SubjectDetail");
        }

    }
}