using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class SubjectDetail
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
    }
}