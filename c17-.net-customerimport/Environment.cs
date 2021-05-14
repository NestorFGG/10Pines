using System;

namespace C17_.Net_CustomerImport
{
    public abstract class Environment
    {
        public static Environment Current()
        {
            if (IntegrationEnvironment.IsCurrent())
            {
                return new IntegrationEnvironment();
            }

            if(DevelopmentEnvironment.IsCurrent())
            {
                return new DevelopmentEnvironment();
            }

            throw new ArgumentException("Invalid environment");
        }

        public abstract ICustomerSystem CreateCustomerSystem();

        public abstract ISupplierSystem CreateSupplierSystem();
    }
}
