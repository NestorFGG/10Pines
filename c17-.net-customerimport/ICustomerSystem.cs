using com.tenpines.advancetdd;

namespace C17_.Net_CustomerImport
{
    public interface ICustomerSystem : ISystem
    {
        Customer CustomerIdentifiedAs(string identificationType, string identificationNumber);
        int NumberOfCustomers();
        void AddCustomer(Customer newCustomer);
    }
}