using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class BiRadsTests
    {
        [TestMethod]
        public void BiRadsEnsureICanCreateInstance()
        {
            BiRads a_BiRads = new BiRads();
            Assert.IsNotNull(a_BiRads);
        }

        [TestMethod]
        public void BiRadsEnsureBiRadsHasAllThings()
        {
            BiRads a_BiRads = new BiRads();
            a_BiRads.BiRadsID = 1;
            a_BiRads.Category = "2";
            a_BiRads.Recommendation = "Benign";

            Assert.AreEqual(1, a_BiRads.BiRadsID);
            Assert.AreEqual("2", a_BiRads.Category);
            Assert.AreEqual("Benign", a_BiRads.Recommendation);
        }

        [TestMethod]
        public void BiRadsEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            BiRads a_BiRads = new BiRads { BiRadsID = 1, Category = "2", Recommendation = "Benign" };

            Assert.AreEqual(1, a_BiRads.BiRadsID);
            Assert.AreEqual("2", a_BiRads.Category);
            Assert.AreEqual("Benign", a_BiRads.Recommendation);
        }
    }
}
