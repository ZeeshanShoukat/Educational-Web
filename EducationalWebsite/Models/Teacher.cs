using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDay { get; set; }
        public string CNIC { get; set; }
        public string ContactNumber { get; set; }
        public string PresentAddress { get; set; }
        public string PermenentAddress { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
    }
}
