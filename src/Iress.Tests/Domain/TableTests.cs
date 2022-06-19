using Iress.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Tests.Domain
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void Table()
        {
            var table = new Table(5, 5);

            Assert.AreNotEqual(Guid.Empty, table.Id);
            Assert.AreEqual(new Coordinate(5, 5), table.Dimension);
        }
    }
}
