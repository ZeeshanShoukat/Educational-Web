using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String FatherName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }

        public String B_Form { get; set; }
        public String Contact { get; set; }
        public String Address { get; set; }

        public Gender Gender { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
       
    }
}