using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class PathologyTests
    {
        [TestMethod]
        public void PathologyEnsureICanCreateInstance()
        {
            Pathology a_pathology = new Pathology();
            Assert.IsNotNull(a_pathology);
        }

        [TestMethod]
        public void PathologyEnsurePathologyHasAllThings()
        {
            Pathology a_pathology = new Pathology();
            a_pathology.PathologyID = 1;
            a_pathology.Classification = "Malignant";
            a_pathology.Type= "IMC";

            Assert.AreEqual(1, a_pathology.PathologyID);
            Assert.AreEqual("Malignant", a_pathology.Classification);
            Assert.AreEqual("IMC", a_pathology.Type);
        }

        [TestMethod]
        public void PathologyEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            Pathology a_pathology = new Pathology { PathologyID = 1, Classification = "Malignant", Type = "IMC" };

            Assert.AreEqual(1, a_pathology.PathologyID);
            Assert.AreEqual("Malignant", a_pathology.Classification);
            Assert.AreEqual("IMC", a_pathology.Type);
        }
    }
}
