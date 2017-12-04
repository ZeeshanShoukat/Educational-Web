using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public String Roll_No { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Class")]
        public int ClassCode { get; set; }
        public ClassSection ClassSection { get; set; }
        [ForeignKey("ClassSection")]
        public int SectionId { get; set; }
        public Session Session { get; set; }
        [ForeignKey("Session")]
        public int SessionId { get; set; }

    }
}