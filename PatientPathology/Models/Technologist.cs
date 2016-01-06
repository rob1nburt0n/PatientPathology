using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class Technologist
    {
        [Key]
        public int TechnologistID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Biopsy ConnectTechnologistToBiopsy { get; set; }
        public RadExam ConnectTechnologistToRadExam { get; set; }
    }
}