using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.tenpines.advancetdd;

namespace C17_.Net_CustomerImport
{
    public class TransientCustomerSystem : ICustomerSystem
    {

        private List<Customer> customers = new List<Customer>();

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void BeginTransaction()
        {
        }

        public void CommitTransaction()
        {
        }

        public Customer CustomerIdentifiedAs(string identificationType, string identificationNumber)
        {
            return customers.First(customer => customer.IsIdentifiedAs(identificationType, identificationNumber));
        }

        public int NumberOfCustomers()
        {
            return customers.Count;
        }

        public void AddCustomer(Customer newCustomer)
        {
            customers.Add(newCustomer);
        }
    }
}
