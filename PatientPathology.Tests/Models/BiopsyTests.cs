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
            a_biopsy.BioType = "Ultrasound";
            a_biopsy.BioDate = "01/15/2015";
            a_biopsy.PathClassification = "Malignant";
            a_biopsy.PathType = "IMC";
            a_biopsy.PatLastName = "Smith";
            a_biopsy.PatDOB = "12/12/1970";
            a_biopsy.ProvLastName = "Jones";
            a_biopsy.TechnologistName = "Jill";


            Assert.AreEqual(1, a_biopsy.BiopsyID);
            Assert.AreEqual("Ultrasound", a_biopsy.BioType);
            Assert.AreEqual("01/15/2015", a_biopsy.BioDate);
            Assert.AreEqual("Malignant", a_biopsy.PathClassification);
            Assert.AreEqual("IMC", a_biopsy.PathType);
            Assert.AreEqual("Smith", a_biopsy.PatLastName);
            Assert.AreEqual("12/12/1970", a_biopsy.PatDOB);
            Assert.AreEqual("Jones", a_biopsy.ProvLastName);
            Assert.AreEqual("Jill", a_biopsy.TechnologistName);

            
        }

        [TestMethod]
        public void BiopsyEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            Biopsy a_biopsy = new Biopsy { BiopsyID = 1, BioType = "Ultrasound", BioDate = "01/15/2015", PathClassification = "Malignant", PathType = "IMC", PatLastName = "Smith", PatDOB = "12/12/1970", ProvLastName = "Jones", TechnologistName = "Jill"};

            Assert.AreEqual(1, a_biopsy.BiopsyID);
            Assert.AreEqual("Ultrasound", a_biopsy.BioType);
            Assert.AreEqual("01/15/2015", a_biopsy.BioDate);
            Assert.AreEqual("Malignant", a_biopsy.PathClassification);
            Assert.AreEqual("IMC", a_biopsy.PathType);
            Assert.AreEqual("Smith", a_biopsy.PatLastName);
            Assert.AreEqual("12/12/1970", a_biopsy.PatDOB);
            Assert.AreEqual("Jones", a_biopsy.ProvLastName);
            Assert.AreEqual("Jill", a_biopsy.TechnologistName);
        }
    }
}
