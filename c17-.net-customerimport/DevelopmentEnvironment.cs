namespace C17_.Net_CustomerImport
{
    public class DevelopmentEnvironment : Environment
    {
        public override ICustomerSystem CreateCustomerSystem()
        {
            return new TransientCustomerSystem();
        }

        public override ISupplierSystem CreateSupplierSystem()
        {
            return new TransientSupplierSystem();
        }

        public static bool IsCurrent()
        {
            return true;
        }
    }
}