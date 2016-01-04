using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class BiRads
    {
        [Key]
        public int BiRadsID { get; set; }
        public string Category { get; set; }
        public string Recommendation { get; set; }
    }
}