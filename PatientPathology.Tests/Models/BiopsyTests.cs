using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class BiopsyTests
    {
        [TestMethod]
        public void BiopsyEnsureICanCreateInstance()
        {
            Biopsy a_biopsy = new Biopsy();
            Assert.IsNotNull(a_biopsy);
        }

        [TestMethod]
        public void BiopsyEnsurePathologyHasAllThings()
        {
            Biopsy a_biopsy = new Biopsy();
            a_biopsy.BiopsyID = 1;
            a_biopsy.Type = "Ultrasound";
            a_biopsy.Date = "01/15/2015";
            a_biopsy.PathologyID = 1;
            a_biopsy.PatientID = 1;
            a_biopsy.ProviderUserID = 1;
            a_biopsy.TechnologistID = 1;
            a_biopsy.RadExamID = 1;

            Assert.AreEqual(1, a_biopsy.BiopsyID);
            Assert.AreEqual("Ultrasound", a_biopsy.Type);
            Assert.AreEqual("01/15/2015", a_biopsy.Date);
            Assert.AreEqual(1, a_biopsy.PathologyID);
            Assert.AreEqual(1, a_biopsy.PatientID);
            Assert.AreEqual(1, a_biopsy.ProviderUserID);
            Assert.AreEqual(1, a_biopsy.TechnologistID);
            Assert.AreEqual(1, a_biopsy.RadExamID);
            
        }

        [TestMethod]
        public void BiopsyEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            Biopsy a_biopsy = new Biopsy { BiopsyID = 1, Type = "Ultrasound", Date = "01/15/2015" };

            Assert.AreEqual(1, a_biopsy.BiopsyID);
            Assert.AreEqual("Ultrasound", a_biopsy.Type);
            Assert.AreEqual("01/15/2015", a_biopsy.Date);
        }
    }
}
