using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;


namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class PatientPathologyTests
    {
        [TestMethod]
        public void PatientEnsureICanCreateInstance()
        {
            Patient a_patient = new Patient();
            Assert.IsNotNull(a_patient);
        }

        [TestMethod]
        public void PatientEnsurePatientHasAllThings()
        {
            Patient a_patient = new Patient();
            a_patient.PatientID = 1;
            a_patient.FirstName = "FirstName";
            a_patient.LastName = "LastName";
            a_patient.DOB = "12/16/1976";
            a_patient.Address = "123 Apple Dr.";
            a_patient.City = "Nashville";
            a_patient.State = "TN";
            a_patient.Zip = "37204";
            a_patient.Phone = "615-322-1234";
            a_patient.Gender = "M";

            Assert.AreEqual(1, a_patient.PatientID);
            Assert.AreEqual("FirstName", a_patient.FirstName);
            Assert.AreEqual("LastName", a_patient.LastName);
            Assert.AreEqual("12/16/1976", a_patient.DOB);
            Assert.AreEqual("123 Apple Dr.", a_patient.Address);
            Assert.AreEqual("Nashville", a_patient.City);
            Assert.AreEqual("TN", a_patient.State);
            Assert.AreEqual("37204", a_patient.Zip);
            Assert.AreEqual("615-322-1234", a_patient.Phone);
            Assert.AreEqual("M", a_patient.Gender);

        }

        [TestMethod]
        public void PatientEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;

            Patient a_patient = new Patient { PatientID = 1, FirstName = "FirstName", LastName = "LastName", DOB = "12/16/1976", Address = "123 Apple Dr.", City = "Nashville", State = "TN", Zip = "37204", Phone = "615-322-1234", Gender = "M" };

            Assert.AreEqual(1, a_patient.PatientID);
            Assert.AreEqual("FirstName", a_patient.FirstName);
            Assert.AreEqual("LastName", a_patient.LastName);
            Assert.AreEqual("12/16/1976", a_patient.DOB);
            Assert.AreEqual("123 Apple Dr.", a_patient.Address);
            Assert.AreEqual("Nashville", a_patient.City);
            Assert.AreEqual("TN", a_patient.State);
            Assert.AreEqual("37204", a_patient.Zip);
            Assert.AreEqual("615-322-1234", a_patient.Phone);
            Assert.AreEqual("M", a_patient.Gender);

        }
    }
}