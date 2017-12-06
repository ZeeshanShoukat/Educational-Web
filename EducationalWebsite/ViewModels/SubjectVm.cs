using EducationalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalWebsite.ViewModels
{
    public class SubjectVm
    {
        public SubjectDetail subjectDetails { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Class> Classes  { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}