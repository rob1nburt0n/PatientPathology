using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

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

        public PtPathRepository(PtPathContext context)
        {
            _context = context;
        }

        public List<Biopsy> GetAllBiopsies()
        {
            var query = from biopsy in _context.Biopsy select biopsy;
            return query.ToList();
        }

        public List<Biopsy> GetUserBiopsy(ProviderUser user)
        {
            if (user != null)
            {
                var query = from u in _context.ProviderUser where u.ProviderUserId == user.ProviderUserId select u;
                var item_query = from i in _context.Biopsy where i.Owner.ProviderUserId == user.ProviderUserId select i;
                List<Biopsy> my_biopsy = item_query.ToList();
                ProviderUser found_user = query.SingleOrDefault<ProviderUser>();


                if (found_user == null)
                {
                    return new List<Biopsy>();
                }
                if (my_biopsy == null)
                {
                    return new List<Biopsy>();
                }
                else
                {
                    return my_biopsy;
                }
            }
            else
            {
                return new List<Biopsy>();
            }
        }

        public List<ProviderUser> GetAllUsers()
        {
            var query = from users in _context.ProviderUser select users;
            return query.ToList();
        }

        public bool AddNewBiopsy(ProviderUser user, int id, string date, string type, string pathclass, string pathtype, string ptname, string ptdob, string provname, string tech)

        {
            bool is_added = true;
            Biopsy new_biopsy = new Biopsy
            {
                Owner = user,
                BioDate = date,
                BioType = type,
                PathClassification = pathclass,
                PathType = pathtype,
                PatLastName = ptname,
                PatDOB = ptdob,
                ProvLastName = provname,
                TechnologistName = tech
            };

            try
            {
                Biopsy added_biopsy = _context.Biopsy.Add(new_biopsy);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
        public List<Biopsy> SearchByType(string search_string)
        {
            var query = from BioType in _context.Biopsy select BioType;
            List<Biopsy> found_items = query.Where(BioType => BioType.BioType.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByDate(string search_string)
        {
            var query = from BioDate in _context.Biopsy select BioDate;
            List<Biopsy> found_items = query.Where(BioDate => BioDate.BioDate.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByClassification(string search_string)
        {
            var query = from PathClassification in _context.Biopsy select PathClassification;
            List<Biopsy> found_items = query.Where(Class => Class.PathClassification.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByPathType(string search_string)
        {
            var query = from PathType in _context.Biopsy select PathType;
            List<Biopsy> found_items = query.Where(PathType => PathType.PathType.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByPatLastName(string search_string)
        {
            var query = from PatLastName in _context.Biopsy select PatLastName;
            List<Biopsy> found_items = query.Where(PtName => PtName.PatLastName.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByPatDOB(string search_string)
        {
            var query = from PatDOB in _context.Biopsy select PatDOB;
            List<Biopsy> found_items = query.Where(DOB => DOB.PatDOB.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByProvName(string search_string)
        {
            var query = from ProvLastName in _context.Biopsy select ProvLastName;
            List<Biopsy> found_items = query.Where(ProvName => ProvName.ProvLastName.Contains(search_string)).ToList();
            return found_items;
        }

        public List<Biopsy> SearchByTechName(string search_string)
        {
            var query = from TechnologistName in _context.Biopsy select TechnologistName;
            List<Biopsy> found_items = query.Where(Tech => Tech.TechnologistName.Contains(search_string)).ToList();
            return found_items;
        }

        public bool AddNewUser(ApplicationUser user)
        {
            ProviderUser new_user = new ProviderUser{RealUser = user, Email = user.Email};
            bool is_added = true;
            try
            {
                ProviderUser added_user = _context.ProviderUser.Add(new_user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
    }
}