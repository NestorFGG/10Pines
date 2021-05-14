using com.tenpines.advancetdd;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

namespace C17_.Net_CustomerImport
{
    public class PersistentCustomerSystem : ICustomerSystem
    {
        private ISession _session;
        public ITransaction _transaction;

        public void Start()
        {
            var storeConfiguration = new StoreConfiguration();

            var configuration = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString("Data Source=CustomerImport.sdf"))
                .Mappings(m => m.AutoMappings.Add(AutoMap
                    .AssemblyOf<Customer>(storeConfiguration)
                    .Override<Customer>(map => map.HasMany(x => x.Addresses).Cascade.All())));

            var sessionFactory = configuration.BuildSessionFactory();
            new SchemaExport(configuration.BuildConfiguration()).Execute(true, true, false);
            this._session = sessionFactory.OpenSession();
        }

        public void Stop()
        {
            this._session.Close();
        }

        public void BeginTransaction()
        {
            this._transaction = this._session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this._transaction.Commit();
        }

        public Customer CustomerIdentifiedAs(string identificationType, string identificationNumber)
        {
            return this._session.CreateCriteria<Customer>().Add(Restrictions.Eq("IdentificationType", identificationType))
                .Add(Restrictions.Eq("IdentificationNumber", identificationNumber)).UniqueResult<Customer>();
        }

        public int NumberOfCustomers()
        {
            return this._session.CreateCriteria<Customer>().List<Customer>().Count;
        }

        public void AddCustomer(Customer newCustomer)
        {
            _session.Persist(newCustomer);
        }
    }
}