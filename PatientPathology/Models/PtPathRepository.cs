using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPathology.Models
{
    public class PtPathRepository
    {
        private PtPathContext _context;
        public PtPathContext Context { get { return _context; } }

        public PtPathRepository()
        {
            _context = new PtPathContext();
        }
    }
}