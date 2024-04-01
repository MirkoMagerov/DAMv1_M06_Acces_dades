using cat.itb.M6UF2EA2.Model;
using Npgsql;

namespace cat.itb.M6UF2EA2.Cruds
{
    public class EmpleatCRUD
    {
        public NpgsqlConnection NpgsqlConnection { get; set; }
        public CloudConnection CloudConnection { get; set; }

        public EmpleatCRUD()
        {
            CloudConnection cloudConnection = new CloudConnection();
            NpgsqlConnection = cloudConnection.NpgsqlConnection();
        }

        public void EX2()
        {
            NpgsqlConnection.Open();

            string sql = "INSERT INTO emp(emp_no, cognom, ofici, cap, data_alta, salari, comissio, dept_no) VALUES(@emp, @cognom, @ofici, @cap, @data_alta, @salari, @comissio, @dept_no)";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            cmd.Parameters.AddWithValue("emp", 4885);
            cmd.Parameters.AddWithValue("cognom", "Borrel");
            cmd.Parameters.AddWithValue("ofici", "Empleat");
            cmd.Parameters.AddWithValue("cap", 7902);
            cmd.Parameters.AddWithValue("data_alta", new DateOnly(1981, 12, 25));
            cmd.Parameters.AddWithValue("salari", 104000);
            cmd.Parameters.AddWithValue("comissio", DBNull.Value);
            cmd.Parameters.AddWithValue("dept_no", 30);
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row inserted");
            }
            else
            {
                Console.WriteLine("Inserted failed");
            }
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("emp", 8772);
            cmd.Parameters.AddWithValue("cognom", "Puig");
            cmd.Parameters.AddWithValue("ofici", "Venedor");
            cmd.Parameters.AddWithValue("cap", 7698);
            cmd.Parameters.AddWithValue("data_alta", new DateOnly(1990, 1, 23));
            cmd.Parameters.AddWithValue("salari", 108000);
            cmd.Parameters.AddWithValue("comissio", DBNull.Value);
            cmd.Parameters.AddWithValue("dept_no", 30);
            if (cmd.ExecuteNonQuery() != 0)
            {
                Console.WriteLine("row inserted");
            }
            else
            {
                Console.WriteLine("Inserted failed");
            }
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("emp", 9945);
            cmd.Parameters.AddWithValue("cognom", "Ferrer");
            cmd.Parameters.AddWithValue("ofici", "Analista");
            cmd.Parameters.AddWithValue("cap", 7698);
            cmd.Parameters.AddWithValue("data_alta", new DateOnly(1988, 5, 17));
            cmd.Parameters.AddWithValue("salari", 169000);
            cmd.Parameters.AddWithValue("comissio", 39000);
            cmd.Parameters.AddWithValue("dept_no", 20);
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

        public void EX5(int codiEmp)
        {
            NpgsqlConnection.Open();

            string sql = $"SELECT * FROM emp WHERE emp_no = {codiEmp}";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            Empleat empleat = new Empleat();

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    empleat.Emp_no = reader.GetInt32(reader.GetOrdinal("emp_no"));
                    empleat.Cognom = reader.GetString(reader.GetOrdinal("cognom"));
                    empleat.Ofici = reader.GetString(reader.GetOrdinal("ofici"));
                    empleat.Cap = reader.GetInt32(reader.GetOrdinal("cap"));
                    empleat.Data_alta = reader.GetDateTime(reader.GetOrdinal("data_alta"));
                    empleat.Salari = reader.GetInt32(reader.GetOrdinal("salari"));
                    empleat.Comissio = !reader.IsDBNull(reader.GetOrdinal("comissio")) ? reader.GetDouble(reader.GetOrdinal("comissio")) : 0.0;
                    empleat.Dept_no = reader.GetInt32(reader.GetOrdinal("dept_no"));
                }
            }

            Console.WriteLine($"Emp_no: {empleat.Emp_no}");
            Console.WriteLine($"Cognom: {empleat.Cognom}");
            Console.WriteLine($"Ofici: {empleat.Ofici}");
            Console.WriteLine($"Cap: {empleat.Cap}");
            Console.WriteLine($"Data_alta: {empleat.Data_alta}");
            Console.WriteLine($"Salari: {empleat.Salari}");
            Console.WriteLine($"Comissio: {empleat.Comissio}");
            Console.WriteLine($"Dept_no: {empleat.Dept_no}");

            NpgsqlConnection.Close();
        }

        public void EX7()
        {
            NpgsqlConnection.Open();

            string sql = $"SELECT * FROM emp";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Cognom: {reader.GetString(reader.GetOrdinal("cognom"))}");
                    Console.WriteLine($"Salari: {reader.GetInt32(reader.GetOrdinal("salari"))}");
                    Console.WriteLine();
                }
            }

            NpgsqlConnection.Close();
        }

        public void EX9(int codiEmp)
        {
            NpgsqlConnection.Open();

            string sql = $"DELETE FROM emp WHERE emp_no = {codiEmp}";
            using var cmd = new NpgsqlCommand(sql, NpgsqlConnection);

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
