using cat.itb.M6UF2EA3.model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace cat.itb.M6UF2EA3.connections
{
    public class SessionFactoryCloud
    {
        private static string ConnectionString = "Server=balarama.db.elephantsql.com;Port=5432;Database=qylrvsaa;User Id=qylrvsaa;Password=WApqM0DJGoMManfagt-fBh-8r8wrRUyI;";
        private static ISessionFactory _session;

        public static ISessionFactory CreateSession()
        {
            if (_session != null) return _session;

            IPersistenceConfigurer configDb = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            FluentConfiguration configMap = Fluently.Configure().Database(configDb)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Departamento>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Empleado>());

            _session = configMap.BuildSessionFactory();

            return _session;
        }
        
        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}