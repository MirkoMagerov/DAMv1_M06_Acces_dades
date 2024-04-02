using cat.itb.M6UF2EA3.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace cat.itb.M6UF2EA3
{
    public class SessionFactoryCloud

    {
        private static string ConnectionString = "Server=manny.db.elephantsql.com;Port=5432;Database=hulyzvle;User Id=hulyzvle;Password=ylLoBYoZhvA5DqLdG_kXgPYRkN6jsDhS;";
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {
            if (session != null) return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap = Fluently.Configure().Database(configDB).Mappings(
                    c => c.FluentMappings.AddFromAssemblyOf<Empleado>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}
