using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace C17_.Net_CustomerImport
{
    [TestClass]
    public class SupplierTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ISupplierSystem supplierSystem = Environment.Current().CreateSupplierSystem();
            SupplierImporter importer = new SupplierImporter(new MemoryStream(), supplierSystem);

            importer.Execute();

            Assert.AreEqual(0,supplierSystem.NumberOfSuppliers());
        }
    }
}
