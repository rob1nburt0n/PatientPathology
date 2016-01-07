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

        public List<Biopsy> GetAllItems()
        {
            var query = from biopsy in _context.Biopsy select biopsy;
            return query.ToList();
        }

        public List<Biopsy> SearchByType(string search_string)
        {
            var query = from BioType in _context.Biopsy select BioType;
            List<Biopsy> found_items = query.Where(Type => Type.BioType.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByDate(string search_string)
        {
            var query = from BioDate in _context.Biopsy select BioDate;
            List<Biopsy> found_items = query.Where(Date => Date.BioDate.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByClassification(string search_string)
        {
            var query = from PathClassification in _context.Biopsy select PathClassification;
            List<Biopsy> found_items = query.Where(Type => Type.PathClassification.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByPathType(string search_string)
        {
            var query = from PathType in _context.Biopsy select PathType;
            List<Biopsy> found_items = query.Where(Type => Type.PathType.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByPatLastName(string search_string)
        {
            var query = from PatLastName in _context.Biopsy select PatLastName;
            List<Biopsy> found_items = query.Where(Type => Type.PatLastName.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByPatDOB(string search_string)
        {
            var query = from PatDOB in _context.Biopsy select PatDOB;
            List<Biopsy> found_items = query.Where(Type => Type.PatDOB.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByProvName(string search_string)
        {
            var query = from ProvLastName in _context.Biopsy select ProvLastName;
            List<Biopsy> found_items = query.Where(Type => Type.ProvLastName.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByTechName(string search_string)
        {
            var query = from TechnologistName in _context.Biopsy select TechnologistName;
            List<Biopsy> found_items = query.Where(Type => Type.TechnologistName.Contains(search_string)).ToList();
            return found_items;
        }
    }
}