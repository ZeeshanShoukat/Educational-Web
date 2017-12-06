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
    public class StudentController : Controller
    {
        static int Studentcode;
        static int StudentDetailId;
        ApplicationDbContext db;
        public StudentController()
        {
            db = new ApplicationDbContext();
            
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        async public Task<ActionResult> StudentDetail()
        {
            var data = await db.StudentDetails.Include("Student").Include("Session").Include("Class").Include("ClassSection").ToListAsync();
            return View(data);
        }
        public ActionResult AddStudent()
        {
            var data = db.Genders.ToList();
            var StdVm = new StudentVm()
            {
                Genders = data,
            };
            return View(StdVm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (student.Id == 0)
            {
                db.Students.Add(student);
                db.SaveChanges();
                var Id = db.Students.SingleOrDefault(e => e.B_Form == student.B_Form).Id;
                Studentcode = Id;
                return RedirectToAction("AddStudentDetail");
            }
            else
            {
                var record = db.Students.SingleOrDefault(m => m.Id == student.Id);
                record.Name = student.Name;
                record.FatherName = student.FatherName;
                record.B_Form = student.B_Form;
                record.GenderId = student.GenderId;
                record.DateofBirth = student.DateofBirth;
                record.Contact = student.Contact;
                record.Address = student.Address;
                db.SaveChanges();
                Studentcode = student.Id;
                var std = db.StudentDetails.Include("student").Include("Session").Include("class").Include("ClassSection").SingleOrDefault(m=>m.Id==StudentDetailId);
                var sessionlist = db.Sessions.ToList();
                var classlist = db.Classes.ToList();
                var sectionlist = db.ClassSections.ToList();
                var stddvm = new StudentVm
                {
                    StudentDetail=std,
                    Sessions=sessionlist,
                    Classes=classlist,
                    ClassSections=sectionlist
                };
                return View("AddStudentDetail",stddvm);

            }

        }
        public ActionResult AddStudentDetail()
        {
            var data = db.Genders.ToList();
            var classdata = db.Classes.ToList();
            var SectionList = db.ClassSections.ToList();
            var SessionList = db.Sessions.ToList();
            var StdVm = new StudentVm()
            {
                Genders = data,
                Classes = classdata,
                ClassSections = SectionList,
                Sessions=SessionList
            };
            return View(StdVm);
        }
        [HttpPost]
        public ActionResult AddStudentDetail(StudentVm student, FormCollection formcollection)
        {
            
            var sessionId = formcollection["SessionId"];
            student.StudentDetail.SessionId = Convert.ToInt32(sessionId);
            student.StudentDetail.StudentID = Studentcode;
            if (student.StudentDetail.Id == 0)
            { 
                db.StudentDetails.Add(student.StudentDetail);
                db.SaveChanges();
            }
            else
            {
                var record = db.StudentDetails.SingleOrDefault(m=>m.Id==student.StudentDetail.Id);
                record.Id = student.StudentDetail.Id;
                record.StudentID = student.StudentDetail.StudentID;
                record.Roll_No = student.StudentDetail.Roll_No;
                record.SectionId = student.StudentDetail.SectionId;
                record.ClassCode = student.StudentDetail.ClassCode;
                record.SessionId = student.StudentDetail.SessionId;
                db.SaveChanges();
            }
            return RedirectToAction("StudentDetail");
        }

        async public Task<ActionResult> UpdateStudent(int id)
        {
            var stdd = await db.StudentDetails.Include(m => m.Student.Gender).Include("session").Include("Class").Include("ClassSection").SingleOrDefaultAsync(m => m.Id==id);
            var std = await db.Students.Where(m => m.Id == stdd.StudentID).Include("Gender").SingleOrDefaultAsync();
            StudentDetailId = stdd.Id;
            var data = db.Genders.ToList();
            //var classlist = db.Classes.ToList();
            //var Sectionlist = db.ClassSections.ToList();
            var StdVm = new StudentVm()
            {
                Student=std,
                StudentDetail = stdd,
                Genders = data,
                //ClassSections= Sectionlist,
            };
            return View("AddStudent", StdVm);
        }
       async public Task<ActionResult> RemoveStudent(int id)
        {
            var std = await db.StudentDetails.Include("Student").SingleOrDefaultAsync(m => m.Id == id);
            db.StudentDetails.Remove(std);
            db.SaveChanges();
            return RedirectToAction("StudentDetail");
        }
        public ActionResult StudentInvoice()
        {
            return View();
        }
        async public Task<ActionResult> StudentProfile(int id)
        {
            var std = await db.StudentDetails.Include(m=>m.Student.Gender).Include("Session").Include("Class").Include("ClassSection").SingleOrDefaultAsync(m => m.Id == id);
            return View(std);
        }

    }
}