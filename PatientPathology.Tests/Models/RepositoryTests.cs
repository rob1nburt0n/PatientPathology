using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class RepositoryTests
    {
        private Mock<PtPathContext> mock_context;
        private Mock<DbSet<Biopsy>> mock_set;
        private Mock<DbSet<ProviderUser>> mock_set_users;
        private PtPathRepository repo;
        private ApplicationUser test_user;
        private ApplicationUser test_user2;

        private void ConnectMocksToDataStore(IEnumerable<Biopsy> data_store)
        {
            var data_source = data_store.AsQueryable();

            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.Provider)
                .Returns(data_source.Provider);
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.Expression)
                .Returns(data_source.Expression);
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.ElementType)
                .Returns(data_source.ElementType);
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.GetEnumerator())
                .Returns(data_source.GetEnumerator);

            mock_context.Setup(a => a.Biopsy).Returns(mock_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<ProviderUser> data_store)
        {
            var data_source = data_store.AsQueryable();

            mock_set_users.As<IQueryable<ProviderUser>>().Setup(data => data.Provider)
                .Returns(data_source.Provider);
            mock_set_users.As<IQueryable<ProviderUser>>().Setup(data => data.Expression)
                .Returns(data_source.Expression);
            mock_set_users.As<IQueryable<ProviderUser>>().Setup(data => data.ElementType)
                .Returns(data_source.ElementType);
            mock_set_users.As<IQueryable<ProviderUser>>().Setup(data => data.GetEnumerator())
                .Returns(data_source.GetEnumerator);

            mock_context.Setup(a => a.ProviderUser).Returns(mock_set_users.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<PtPathContext>();
            mock_set = new Mock<DbSet<Biopsy>>();
            mock_set_users = new Mock<DbSet<ProviderUser>>();
            repo = new PtPathRepository(mock_context.Object);
            test_user = new ApplicationUser { Email = "Smith@gmail.com", Id = "MyId" };
            test_user2 = new ApplicationUser { Email = "Jonesgmail.com", Id = "MyId2" };

        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            mock_set_users = null;
            repo = null;
            test_user = null;
            test_user2 = null;

        }


        [TestMethod]
        public void RepoEnsureICanCreateInstanceOfRepository()
        {
            PtPathRepository repo = new PtPathRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureICanCreateInstanceOfContext()
        {
            PtPathContext context = new PtPathContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void RepoEnsureIHaveAContext()
        {
            PtPathRepository repo = new PtPathRepository();
            var actual = repo.Context;

            Assert.IsInstanceOfType(actual, typeof(PtPathContext));
        }

        [TestMethod]
        public void RepoEnsureICanGetAllBiopsies()
        {
            var expected = new List<Biopsy>
            {
                new Biopsy {BioType = "Ultrasound"},
                new Biopsy {BioType = "Stereotactic"}
            };

            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            var actual = repo.GetAllBiopsies();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepoEnsureICanGetAllUsers()
        {
            var expected = new List<ProviderUser>
            {
                new ProviderUser {ProviderUserId = 1},
                new ProviderUser {ProviderUserId = 2},
                new ProviderUser {ProviderUserId = 3}
            };

            mock_set_users.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            var actual = repo.GetAllUsers();

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RepoEnsureICanAddANewUser()
        {
            List<ProviderUser> emptyDB = new List<ProviderUser>(); //This is the empty database table
            ConnectMocksToDataStore(emptyDB);

            mock_set_users.Setup(i => i.Add(It.IsAny<ProviderUser>())).Callback((ProviderUser s) => emptyDB.Add(s));

            bool added = repo.AddNewUser(test_user);

            ProviderUser stock_user = repo.GetAllUsers().Where(u => u.RealUser.Id == test_user.Id).SingleOrDefault();
            Assert.IsNotNull(stock_user);
            Assert.IsTrue(added);
            Assert.AreEqual(1, repo.GetAllUsers().Count);
        }

        [TestMethod]
        public void RepoEnsureICanAddANewBiopsy()
        {
            ProviderUser user = new ProviderUser { ProviderUserId = 500 };

            List<Biopsy> emptyDB = new List<Biopsy>(); //This is the empty database
            ConnectMocksToDataStore(emptyDB);

            int BiopsyID = 1;
            ProviderUser provider = user;
            string BioType = "Ultrasound";
            string BioDate = "2/4/2015";
            string PathClassification = "Malignant";
            string PathType = "IMC";
            string PatLastName = "Jones";
            string PatDOB = "12/5/1965";
            string ProvLastName = "Han";
            string TechnologistName = "Suzy";

            //Listen for any item trying to be added to the database. When you see one add it to emptyDB
            mock_set.Setup(i => i.Add(It.IsAny<Biopsy>())).Callback((Biopsy s) => emptyDB.Add(s));

            bool added = repo.AddNewBiopsy(user, BiopsyID, BioType, BioDate, PathClassification, PathType, PatLastName, PatDOB, ProvLastName, TechnologistName);

            Assert.IsTrue(added);
            Assert.AreEqual(1, repo.GetAllBiopsies().Count);
        }

        [TestMethod]
        public void RepoSearchByBiopsyType()
        {
            var expected = new List<Biopsy>
            {
                new Biopsy {BioType = "Ultrasound" },
                new Biopsy {BioType = "Ultrasound" },
                new Biopsy {BioType = "Stereotactic" }
            };

            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            string search_string = "Ultrasound";

            List<Biopsy> expected_types = new List<Biopsy>
            {
                new Biopsy {BioType = "Ultrasound" },
                new Biopsy {BioType = "Ultrasound" }
            };

            List<Biopsy> actual_types = repo.SearchByType(search_string);

            Assert.AreEqual(expected_types[0].BioType, actual_types[0].BioType);
            Assert.AreEqual(expected_types[1].BioType, actual_types[1].BioType);
        }
    }
}
