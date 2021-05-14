using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text;
using com.tenpines.advancetdd;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Util;

namespace C17_.Net_CustomerImport
{
    [TestClass]
    public class CustomerTest
    {
        private readonly ICustomerSystem _persistentCustomerSystem = C17_.Net_CustomerImport.Environment.Current().CreateCustomerSystem();

        [TestMethod]
        public void ValidDataImportedCorrectly()
        {
            new CustomerImporter(ValidData(), _persistentCustomerSystem).Execute();

            AssertNumberOfCustomersImport();
            AssertFirstRecordWasImportCorrectly();
            AssertSecondRecordWasImportCorrectly();
        }

        private void AssertSecondRecordWasImportCorrectly()
        {
            var customer = _persistentCustomerSystem.CustomerIdentifiedAs("C", "23-25666777-9");

            AssertCustomerWasImportedWith(customer, "Juan", "Perez", "C", "23-25666777-9");
            
            AssertCustomerHasAddressAt(customer, "Alem", 1122, "CABA", 1001, "CABA");
        }

        private void AssertFirstRecordWasImportCorrectly()
        {
            var customer = _persistentCustomerSystem.CustomerIdentifiedAs("D", "22333444");

            AssertCustomerWasImportedWith(customer, "Pepe", "Sanchez", "D", "22333444");

            AssertCustomerHasAddressAt(customer, "San Martin", 3322, "Olivos", 1636, "BsAs");
        }

        private static void AssertCustomerHasAddressAt(Customer customer, string streetName, int streetNumber, string town, int zipCode, string province)
        {
            var address = customer.GetAddressAt(streetName);

            Assert.AreEqual(streetName, address.StreetName);
            Assert.AreEqual(streetNumber, address.StreetNumber);
            Assert.AreEqual(town, address.Town);
            Assert.AreEqual(zipCode, address.ZipCode);
            Assert.AreEqual(province, address.Province);
        }

        private static void AssertCustomerWasImportedWith(Customer customer, string firstName, string lastName,
            string identificationType, string identificationNumber)
        {
            Assert.AreEqual(firstName, customer.FirstName);
            Assert.AreEqual(lastName, customer.LastName);
            Assert.AreEqual(identificationType, customer.IdentificationType);
            Assert.AreEqual(identificationNumber, customer.IdentificationNumber);
        }

        private void AssertNumberOfCustomersImport()
        {
            int numberOfCustomers = _persistentCustomerSystem.NumberOfCustomers();
            Assert.AreEqual(2, numberOfCustomers);
        }

        private static MemoryStream ValidData()
        {
            StringWriter writer = new StringWriter();
            writer.Write("C,Pepe,Sanchez,D,22333444\n");
            writer.Write("A,San Martin,3322,Olivos,1636,BsAs\n");
            writer.Write("A,Maipu,888,Florida,1122,Buenos Aires\n");
            writer.Write("C,Juan,Perez,C,23-25666777-9\n");
            writer.Write("A,Alem,1122,CABA,1001,CABA\n");

            byte[] byteArray = Encoding.UTF8.GetBytes(writer.ToString());

            MemoryStream memoryStream = new MemoryStream(byteArray);
            return memoryStream;
        }

        [TestCleanup]
        public void AfterTest()
        {
            _persistentCustomerSystem.CommitTransaction();
            _persistentCustomerSystem.Stop();
        }

        [TestInitialize]
        public void Setup()
        {
            _persistentCustomerSystem.Start();
            _persistentCustomerSystem.BeginTransaction();
        }
    }
}
