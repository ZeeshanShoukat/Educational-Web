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
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (student.Id == 0)
            {
                db.Students.Add(student);
                db.SaveChanges();

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
            }
            var Id = db.Students.SingleOrDefault(e=>e.B_Form==student.B_Form).Id;
            Studentcode = Id;
            return RedirectToAction("AddStudentDetail");
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
                //var record = db.Students.SingleOrDefault(m => m.Id == student.Id);
                //record.Roll_No = student.Roll_No;
                //record.Name = student.Name;
                //record.FatherName = student.FatherName;
                //record.B_Form = student.B_Form;
                //record.GenderId = student.GenderId;
                //record.DateofBirth = student.DateofBirth;
                //record.Contact = student.Contact;
                //record.Address = student.Address;
                //record.ClassCode = student.ClassCode;
                //record.ClassSection = student.ClassSection;
                //db.SaveChanges();
            }
            return RedirectToAction("StudentDetail");
        }

        async public Task<ActionResult> UpdateStudent(int id)
        {
            var std = await db.StudentDetails.Include(m=>m.Student.Gender).Include("class").Include("ClassSection").SingleOrDefaultAsync(m => m.Id == id);
            var data = db.Genders.ToList();
            var classlist = db.Classes.ToList();
            var Sectionlist = db.ClassSections.ToList();
            var StdVm = new StudentVm()
            {
                StudentDetail = std,
                Genders = data,
                 ClassSections= Sectionlist,
                Classes = classlist

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