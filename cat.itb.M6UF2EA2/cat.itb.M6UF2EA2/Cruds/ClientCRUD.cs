using cat.itb.M6UF2EA2.Model;
using Npgsql;

namespace cat.itb.M6UF2EA2.Cruds
{
    public class ClientCRUD
    {
        public NpgsqlConnection NpgsqlConnection { get; set; }
        public CloudConnection CloudConnection { get; set; }

        public ClientCRUD()
        {
            CloudConnection cloudConnection = new CloudConnection();
            NpgsqlConnection = cloudConnection.NpgsqlConnection();
        }

        public void EX3()
        {
            NpgsqlConnection.Open();

            string sql = "UPDATE client SET limit_credit = @credit WHERE client_cod = @cod";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            cmd.Parameters.AddWithValue("@cod", 104);
            cmd.Parameters.AddWithValue("@credit", 20000);
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row updated");
            }
            else
            {
                Console.WriteLine("Update failed");
            }
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@cod", 106);
            cmd.Parameters.AddWithValue("@credit", 12000);
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row updated");
            }
            else
            {
                Console.WriteLine("Update failed");
            }
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@cod", 107);
            cmd.Parameters.AddWithValue("@credit", 20000);
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row updated");
            }
            else
            {
                Console.WriteLine("Update failed");
            }
            cmd.Parameters.Clear();

            NpgsqlConnection.Close();
        }

        public void EX4(int codiClient)
        {
            NpgsqlConnection.Open();

            string sql = $"SELECT * FROM client WHERE client_cod = {codiClient}";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            Client client = new Client();

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    client.Client_cod = reader.GetInt32(reader.GetOrdinal("client_cod"));
                    client.Nom = reader.GetString(reader.GetOrdinal("nom"));
                    client.Adreca = reader.GetString(reader.GetOrdinal("adreca"));
                    client.Ciutat = reader.GetString(reader.GetOrdinal("ciutat"));
                    client.Estat = reader.GetString(reader.GetOrdinal("estat"));
                    client.Codi_postal = reader.GetString(reader.GetOrdinal("codi_postal"));
                    client.Area = reader.GetInt32(reader.GetOrdinal("area"));
                    client.Telefon = reader.GetString(reader.GetOrdinal("telefon"));
                    client.Repr_cod = reader.GetInt32(reader.GetOrdinal("repr_cod"));
                    client.Limit_credit = reader.GetDouble(reader.GetOrdinal("limit_credit"));
                    client.Observacions = reader.GetString(reader.GetOrdinal("observacions"));
                }
            }

            Console.WriteLine($"Client_cod: {client.Client_cod}");
            Console.WriteLine($"Nom: {client.Nom}");
            Console.WriteLine($"Adreca: {client.Adreca}");
            Console.WriteLine($"Ciutat: {client.Ciutat}");
            Console.WriteLine($"Estat: {client.Estat}");
            Console.WriteLine($"Codi_postal: {client.Codi_postal}");
            Console.WriteLine($"Area: {client.Area}");
            Console.WriteLine($"Telefon: {client.Telefon}");
            Console.WriteLine($"Repr_cod: {client.Repr_cod}");
            Console.WriteLine($"Limit_credit: {client.Limit_credit}");
            Console.WriteLine($"Observacions: {client.Observacions}");

            NpgsqlConnection.Close();
        }

        public void EX8(int codiClient)
        {
            NpgsqlConnection.Open();

            string sql = $"DELETE FROM client WHERE client_cod = {codiClient}";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            cmd.Prepare();
            
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("Deleted successfully");
            }
            else
            {
                Console.WriteLine("Error with the delete");
            }

            NpgsqlConnection.Close();
        }
    }
}
