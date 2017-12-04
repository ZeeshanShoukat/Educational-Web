using EducationalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalWebsite.ViewModels
{
    public class ClassVm
    {
        public ClassDetail classDetail { get; set; }

        public IEnumerable<Class> Classes { get; set; }

        public IEnumerable<ClassSection> ClassSections { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }


    }
}