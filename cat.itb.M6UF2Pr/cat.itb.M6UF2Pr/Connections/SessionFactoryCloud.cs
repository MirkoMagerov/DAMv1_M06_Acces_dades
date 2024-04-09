using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace cat.itb.M6UF2EA3
    {
        public class SessionFactoryCloud
        {
            private static string ConnectionString = "Server=flora.db.elephantsql.com;Port=5432;Database=ioheyjvq;User Id=ioheyjvq;Password=6pI_3-RZQlhtD7-6j66wMyNz9kzLx3S2;";
            private static ISessionFactory session;

            public static ISessionFactory CreateSession()
            {
                if (session != null) return session;

                IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
                    var configMap = Fluently.Configure().Database(configDB).Mappings(
                    c => c.FluentMappings.AddFromAssemblyOf<Order>()
                                         .AddFromAssemblyOf<Employee>()
                                         .AddFromAssemblyOf<Product>()
                                         .AddFromAssemblyOf<Supplier>());

                session = configMap.BuildSessionFactory();

                return session;
            }

            public static ISession Open()
            {
                return CreateSession().OpenSession();
            }
        }
    }
