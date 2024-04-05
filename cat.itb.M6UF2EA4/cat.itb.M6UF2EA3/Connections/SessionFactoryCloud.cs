using cat.itb.M6UF2EA3.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace cat.itb.M6UF2EA3
{
    public class SessionFactoryCloud
    {
        private static string ConnectionString = "Server=manny.db.elephantsql.com;Port=5432;Database=mhycdeku;User Id=mhycdeku;Password=BHfG-d2wbz7tVtrdJtn9K48ak67ZUzci;";
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {
            if (session != null) return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap = Fluently.Configure().Database(configDB).Mappings(
                    c => c.FluentMappings.AddFromAssemblyOf<Empleado>()
                                         .AddFromAssemblyOf<Departamento>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}
