using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationalWebsite.Models
{
    public class Class
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}