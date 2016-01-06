using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class RadExam
    {
        [Key]
        public int RadExamID { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        [ForeignKey("ProviderUser")]
        public int ProviderUserID { get; set; }
        [ForeignKey("BiRads")]
        public int BiRadsID { get; set; }
        [ForeignKey("Technologist")]
        public int TechnologistID { get; set; }
    }
}