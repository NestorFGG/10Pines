using System.Collections.Generic;
using com.tenpines.advancetdd;

namespace C17_.Net_CustomerImport
{
    public class TransientSupplierSystem : ISupplierSystem
    {
        private List<Supplier> _suppliers = new List<Supplier>();

        public int NumberOfSuppliers()
        {
            return _suppliers.Count;
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new System.NotImplementedException();
        }
    }
}