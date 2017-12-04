using EducationalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalWebsite.ViewModels
{
    public class StudentVm
    {
        public Student Student {get; set; }
        public StudentDetail StudentDetail { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<ClassSection> ClassSections { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
    }
}