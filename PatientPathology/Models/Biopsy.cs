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
        public string Date { get; set; }
        public string Type { get; set; }

        [ForeignKey("Pathology")]
        public int PathologyID { get; set; }
       
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        
        [ForeignKey("ProviderUser")]
        public int ProviderUserID { get; set; }
        
        [ForeignKey("Technologist")]
        public int TechnologistID { get; set; }
       
        [ForeignKey("RadExam")]
        public int RadExamID { get; set; }
    }
        
}
