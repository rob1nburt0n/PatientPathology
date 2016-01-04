using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class TechnologistTests
    {
        [TestMethod]
        public void TechnologistEnsureICanCreateInstance()
        {
            Technologist a_technologist = new Technologist();
            Assert.IsNotNull(a_technologist);
        }

        [TestMethod]
        public void TechnologistEnsureTechnologistHasAllThings()
        {
            Technologist a_technologist = new Technologist();
            a_technologist.TechnologistID = 1;
            a_technologist.FirstName = "FirstName";
            a_technologist.LastName = "LastName";

            Assert.AreEqual(1, a_technologist.TechnologistID);
            Assert.AreEqual("FirstName", a_technologist.FirstName);
            Assert.AreEqual("LastName", a_technologist.LastName);
        }

        [TestMethod]
        public void TechnologistEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            Technologist a_technologist = new Technologist { TechnologistID = 1, FirstName = "FirstName", LastName = "LastName"};

            Assert.AreEqual(1, a_technologist.TechnologistID);
            Assert.AreEqual("FirstName", a_technologist.FirstName);
            Assert.AreEqual("LastName", a_technologist.LastName);
        }
    }
}

