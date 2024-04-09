using Npgsql;

namespace cat.itb.M6UF2Pr.Connections
{
    public class CloudConnection
    {
        private String HOST = "flora.db.elephantsql.com:5432";
        private String DB = "ioheyjvq";
        private String USER = "ioheyjvq";
        private String PASSWORD = "6pI_3-RZQlhtD7-6j66wMyNz9kzLx3S2";

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                "Host=" + HOST + ";" + "Username=" + USER + ";" +
                "Password=" + PASSWORD + ";" + "Database=" + DB + ";");

            conn.Open();
            return conn;
        }
    }
}
