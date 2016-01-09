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
            a_user.ProviderUserId = 1;
            a_user.Email = "Adam@gmail.com";
           
            Assert.AreEqual(1, a_user.ProviderUserId);
            Assert.AreEqual("Adam@gmail.com", a_user.Email);
            
        }

    }
}
