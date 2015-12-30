using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}