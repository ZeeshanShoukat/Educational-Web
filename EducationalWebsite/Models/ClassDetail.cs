using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class ClassDetail
    {
        
        public int Id { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public ClassSection ClassSection { get; set; }
        [ForeignKey("ClassSection")]
        public int ClassSctionId { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Session Session { get; set; }
        [ForeignKey("Session")]
        public int SessionId { get; set; }
    }
}