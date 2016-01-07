using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class PtPathContext : ApplicationDbContext 
    {
        public virtual DbSet<ProviderUser> ProviderUser { get; set; }
        public virtual DbSet<Biopsy> Biopsy { get; set; }

    }
}