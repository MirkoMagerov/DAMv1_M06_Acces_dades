
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using UF2_test.model;

namespace UF2_test;

public class SessionFactoryCloud
    
{
    private static string ConnectionString = "Server=balarama.db.elephantsql.com;Port=5432;Database=qylrvsaa;User Id=qylrvsaa;Password=WApqM0DJGoMManfagt-fBh-8r8wrRUyI;";	
    private static ISessionFactory session;

    public static ISessionFactory CreateSession()
    {
        if (session != null)
            return session;

        IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
        var configMap =
            Fluently.Configure().Database(configDB).Mappings(
                c => c.FluentMappings.AddFromAssemblyOf<Student>());
    
        session = configMap.BuildSessionFactory();

        return session;
    }

    public static ISession Open()
    {
        return CreateSession().OpenSession();
    }
}

