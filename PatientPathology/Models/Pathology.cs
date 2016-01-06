using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class Pathology
    {
        [Key]
        public int PathologyID { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }

        public Biopsy ConnectPathologyToBiopsy { get; set; }
        public RadExam ConnectPathologyToRadExam { get; set; }
    }
}