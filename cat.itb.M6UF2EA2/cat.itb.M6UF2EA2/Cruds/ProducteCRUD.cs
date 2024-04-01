using Npgsql;
using cat.itb.M6UF2EA2.Model;

namespace cat.itb.M6UF2EA2.Cruds
{
    public class ProducteCRUD
    {
        public NpgsqlConnection NpgsqlConnection { get; set; }
        public CloudConnection CloudConnection { get; set; }

        public ProducteCRUD()
        {
            CloudConnection cloudConnection = new CloudConnection();
            NpgsqlConnection = cloudConnection.NpgsqlConnection();
        }

        public void EX1()
        {
            NpgsqlConnection.Open();

            string sql = "INSERT INTO producte(prod_num,descripcio) VALUES(@codi, @desc)";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            cmd.Parameters.AddWithValue("codi", 300388);
            cmd.Parameters.AddWithValue("desc", "RH GUIDE TO PADDLE");
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row inserted");
            }
            else
            {
                Console.WriteLine("Inserted failed");
            }
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("codi", 400552);
            cmd.Parameters.AddWithValue("desc", "RH GUIDE TO BOX");
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row inserted");
            }
            else
            {
                Console.WriteLine("Inserted failed");
            }
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("codi", 400333);
            cmd.Parameters.AddWithValue("desc", "ACE TENNIS BALLS-10 PACK");
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row inserted");
            }
            else
            {
                Console.WriteLine("Inserted failed");
            }
            cmd.Parameters.Clear();

            NpgsqlConnection.Close();
        }

        public void EX6(int codiProd)
        {
            NpgsqlConnection.Open();

            string sql = $"SELECT * FROM producte WHERE prod_num = {codiProd}";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            Producte producte = new Producte();

            cmd.Prepare();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    producte.Prod_num = reader.GetInt32(reader.GetOrdinal("prod_num"));
                    producte.Descripcio = reader.GetString(reader.GetOrdinal("descripcio"));
                }
            }

            Console.WriteLine($"Prod_num: {producte.Prod_num}");
            Console.WriteLine($"Descripcio: {producte.Descripcio}");

            NpgsqlConnection.Close();
        }

        public void EX10(int codiProd)
        {
            NpgsqlConnection.Open();

            string sql = $"DELETE FROM producte WHERE prod_num = {codiProd}";
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
