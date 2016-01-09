using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class ProviderUser 
    {
        [Key]
        public int ProviderUserId { get; set; }
        public virtual ApplicationUser RealUser { get; set; }

        public string Email { get; set; }
   
        public List<Biopsy> Biopsy { get; set; }  
    }
}