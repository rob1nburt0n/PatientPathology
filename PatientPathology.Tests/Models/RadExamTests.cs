using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class RadExamTests
    {
        [TestMethod]
        public void RadExamEnsureICanCreateInstance()
        {
            RadExam a_RadExam = new RadExam();
            Assert.IsNotNull(a_RadExam);
        }

        [TestMethod]
        public void RadExamEnsureRadExamHasAllThings()
        {
            RadExam a_RadExam = new RadExam();
            a_RadExam.RadExamID = 1;
            a_RadExam.Type = "Mammogram";
            a_RadExam.Date = "01/15/2015";
            a_RadExam.PatientID = 1;
            a_RadExam.ProviderUserID = 1;
            a_RadExam.BiRadsID = 1;
            a_RadExam.TechnologistID = 1;

            Assert.AreEqual(1, a_RadExam.RadExamID);
            Assert.AreEqual("Mammogram", a_RadExam.Type);
            Assert.AreEqual("01/15/2015", a_RadExam.Date);
            Assert.AreEqual(1, a_RadExam.PatientID);
            Assert.AreEqual(1, a_RadExam.ProviderUserID);
            Assert.AreEqual(1, a_RadExam.BiRadsID);
            Assert.AreEqual(1, a_RadExam.TechnologistID);

        }

        [TestMethod]
        public void RadExamEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            RadExam a_RadExam = new RadExam { RadExamID = 1, Type = "Mammogram", Date = "01/15/2015" };

            Assert.AreEqual(1, a_RadExam.RadExamID);
            Assert.AreEqual("Mammogram", a_RadExam.Type);
            Assert.AreEqual("01/15/2015", a_RadExam.Date);
        }

    }
}
