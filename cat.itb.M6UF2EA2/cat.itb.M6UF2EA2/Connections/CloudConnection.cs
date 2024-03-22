using Npgsql;

namespace cat.itb.M6UF2EA2
{
    public class CloudConnection
    {
        public NpgsqlConnection NpgsqlConnection()
        {
            string host = "flora.db.elephantsql.com:5432";
            string user = "wzpmjfpc";
            string database = "wzpmjfpc";
            string password = "IxRRxvBlI4jrQv2hbQMR3o5pHy2ReoV-";

            string connectionString = $"Host={host};Username={user};Database={database};Password={password}";

            return new NpgsqlConnection(connectionString);
        }
    }
}
