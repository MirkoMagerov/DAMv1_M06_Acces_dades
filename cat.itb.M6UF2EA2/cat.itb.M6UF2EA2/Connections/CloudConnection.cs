using Npgsql;

namespace cat.itb.M6UF2EA2
{
    public class CloudConnection
    {
        public NpgsqlConnection NpgsqlConnection()
        {
            string host = "mel.db.elephantsql.com:5432";
            string user = "skdrxzrf";
            string database = "skdrxzrf";
            string password = "q5ZJUvFGtkHcTJRDPnjRnTVEtX9UeT1F";

            string connectionString = $"Host={host};Username={user};Database={database};Password={password}";

            return new NpgsqlConnection(connectionString);
        }
    }
}
