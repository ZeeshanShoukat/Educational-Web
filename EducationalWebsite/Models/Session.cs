using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}