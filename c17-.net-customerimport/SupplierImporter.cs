using System.IO;
using com.tenpines.advancetdd;

namespace C17_.Net_CustomerImport
{
    public class SupplierImporter: Importer
    {
        private ISupplierSystem _supplierSystem;

        public SupplierImporter(Stream fileStream, ISupplierSystem supplierSystem) : base(fileStream)
        {
            _supplierSystem = supplierSystem;
        }

        protected override void GetRecord()
        {
            throw new System.NotImplementedException();
        }

        protected override void ImportRecord()
        {
            throw new System.NotImplementedException();
        }

        protected override void ImportAddress()
        {
            throw new System.NotImplementedException();
        }

        protected override void ImportCustomer()
        {
            throw new System.NotImplementedException();
        }

        protected override bool IsAddressRecord()
        {
            throw new System.NotImplementedException();
        }

        protected override bool IsCustomerRecord()
        {
            throw new System.NotImplementedException();
        }

    }
}