using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.tenpines.advancetdd;
using NHibernate;
using Remotion.Linq.Utilities;

namespace C17_.Net_CustomerImport
{
    public class CustomerImporter : Importer
    {
        private Customer _newCustomer;
        private ICustomerSystem _customerSystem;

        public CustomerImporter(Stream fileStream, ICustomerSystem customerSystem) : base(fileStream)
        {
            _customerSystem = customerSystem;
        }

        protected override void GetRecord()
        {
            _record = _line.Split(',');
        }

        protected override void ImportRecord()
        {
            if (IsCustomerRecord())
            {
                ImportCustomer();
            }
            else if (IsAddressRecord())
            {
                ImportAddress();
            }
            else
            {
                throw new ArgumentException("Invalid record");
            }
        }

        protected override void ImportAddress()
        {
            var addressData = _record;
            var newAddress = new Address();

            _newCustomer.AddAddress(newAddress);
            newAddress.StreetName = addressData[1];
            newAddress.StreetNumber = int.Parse(addressData[2]);
            newAddress.Town = addressData[3];
            newAddress.ZipCode = int.Parse(addressData[4]);
            newAddress.Province = addressData[5];
        }

        protected override void ImportCustomer()
        {
            _newCustomer = new Customer();
            _newCustomer.FirstName = _record[1];
            _newCustomer.LastName = _record[2];
            _newCustomer.IdentificationType = _record[3];
            _newCustomer.IdentificationNumber = _record[4];
            _customerSystem.AddCustomer(_newCustomer);
        }

        protected override bool IsAddressRecord()
        {
            return _line.StartsWith("A");
        }

        protected override bool IsCustomerRecord()
        {
            return _line.StartsWith("C");
        }
    }
}
