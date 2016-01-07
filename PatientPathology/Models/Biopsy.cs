using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class Biopsy
    {
        [Key]
        public int BiopsyID { get; set; }
        public string BioDate { get; set; }
        public string BioType { get; set; }
        public string PathClassification { get; set; }
        public string PathType { get; set; }
        public string PatLastName { get; set; }
        public string PatDOB { get; set; }
        public string ProvLastName { get; set; }
        public string TechnologistName { get; set; }
    }
        
}
