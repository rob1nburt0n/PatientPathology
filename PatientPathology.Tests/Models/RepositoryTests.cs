using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPathology.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace PatientPathology.Tests.Models
{
    [TestClass]
    public class RepositoryTests
    {
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
        public void RepoEnsureICanGetAllBiopsies()
        {
            var expected = new Biopsy
            {
                new Biopsy {BioType = "Ultrasound"}
            };

            Mock<PtPathContext> mock_context = new Mock<PtPathContext>();
            Mock<DbSet<Biopsy>> mock_set = new Mock<DbSet<Biopsy>>();

            mock_set.Object.AddRange(expected);
            var data_source = expected.AsQueryable();
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.Provider)
                .Returns(data_source.Provider);
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.Expression)
                .Returns(data_source.Expression);
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.ElementType)
                .Returns(data_source.ElementType);
            mock_set.As<IQueryable<Biopsy>>().Setup(data => data.GetEnumerator())
                .Returns(data_source.GetEnumerator);

            mock_context.Setup(a => a.Items).Returns(mock_set.Object);
            PtPathRepository repo = new PtPathRepository(mock_context.Object);
            var actual = repo.GetAllItems();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
