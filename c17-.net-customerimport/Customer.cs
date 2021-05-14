using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using C17_.Net_CustomerImport;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;


namespace com.tenpines.advancetdd
{

    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type == typeof(Customer) || type == typeof(Address) || type == typeof(Supplier);
        }
    }

    public class Address
    {
        public virtual Guid Id { get; set; }
        public virtual string StreetName { get; set; }
        public virtual int StreetNumber { get; set; }
        public virtual string Town { get; set; }
        public virtual int ZipCode { get; set; }
        public virtual string Province { get; set; }
    }


    public class Customer
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdentificationType { get; set; }
        public virtual string IdentificationNumber { get; set; }
        public virtual IList<Address> Addresses { get; set; }

        public Customer()
        {
            Addresses = new List<Address>();
        }

        public virtual void AddAddress(Address anAddress)
        {
            Addresses.Add(anAddress);
        }

        public static void Main(string[] args)
        {
        }


        public virtual Address GetAddressAt(string streetName)
        {
            return Addresses.First(a => a.StreetName == streetName);
        }

        public virtual bool IsIdentifiedAs(string customerIdentificationType, string customerIdentificationNumber)
        {
            return IdentificationType.Equals(customerIdentificationType) &&
                   IdentificationNumber.Equals(customerIdentificationNumber);
        }
    }

    public class Supplier
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IdentificationType { get; set; }
        public virtual string IdentificationNumber { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Customer> Customers { get; set; }

        public Supplier()
        {
            Addresses = new List<Address>();
            Customers = new List<Customer>();
        }


    }


}
