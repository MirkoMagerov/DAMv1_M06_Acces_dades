using Npgsql;

namespace UF2_test;

public class CloudConnection
{
    private String HOST = "balarama.db.elephantsql.com:5432"; // Ubicació de la BD.
    private String DB = "qylrvsaa"; // Nom de la BD.
    private String USER = "qylrvsaa";
    private String PASSWORD = "WApqM0DJGoMManfagt-fBh-8r8wrRUyI";

    // Specify connection options and open an connection
    public NpgsqlConnection conn = null;

    /**
     * Mètode per connectar a la base de dades school
     */
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