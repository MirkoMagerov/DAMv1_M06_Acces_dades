using Npgsql;

namespace cat.itb.M6UF2EA1
{
    public class SchoolConnection
    {
        private string HOST = "flora.db.elephantsql.com:5432";
        private string DB = "vvgfrvqa";
        private string USER = "vvgfrvqa";
        private string PASSWORD = "m1SnCc0KJnnJwzjBU-8NZzBxVfSk1w6S";

        public NpgsqlConnection conn;

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                "Host=" + HOST + ";" + "Username=" + USER + ";" +
                "Password=" + PASSWORD + ";" + "Database=" + DB + ";"
            );
            conn.Open();
            return conn;
        }
    }
}
