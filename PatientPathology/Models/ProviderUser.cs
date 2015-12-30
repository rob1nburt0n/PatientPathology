﻿using System;
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

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        [RegularExpression(@"^[a-zA-Z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public string Handle { get; set; }
        public string Title { get; set; }


    }
}