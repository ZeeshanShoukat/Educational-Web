using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSection> ClassSections  { get; set; }
        public DbSet<ClassDetail> ClassDetails { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectDetail> SubjectDetails { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Exam> Exams { get; set; }






        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}