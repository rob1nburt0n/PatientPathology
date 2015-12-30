using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class ProviderUserTests
    {
        [TestMethod]
        public void ProviderUserEnsureICanCreateInstance()
        {
            ProviderUser a_user = new ProviderUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void ProviderUserEnsureProviderUserHasAllThings()
        {
            ProviderUser a_user = new ProviderUser();
            a_user.Handle = "adam1";
            a_user.FirstName = "Adam";
            a_user.LastName = "Sand";
            a_user.Title = "Radiologist";

            Assert.AreEqual("adam1", a_user.Handle);
            Assert.AreEqual("Adam", a_user.FirstName);
            Assert.AreEqual("Sand", a_user.LastName);
            Assert.AreEqual("Radiologist", a_user.Title);

        }
    }
}
