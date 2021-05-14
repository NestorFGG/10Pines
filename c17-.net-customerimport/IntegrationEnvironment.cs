namespace C17_.Net_CustomerImport
{
    public class IntegrationEnvironment : Environment
    {
        public override ICustomerSystem CreateCustomerSystem()
        {
            return new PersistentCustomerSystem();
        }

        public override ISupplierSystem CreateSupplierSystem()
        {
            return new PersistentSupplierSystem();
        }

        public static bool IsCurrent()
        {
            return false;
        }
    }
}