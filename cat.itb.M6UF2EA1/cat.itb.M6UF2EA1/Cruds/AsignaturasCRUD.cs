using Npgsql;
using System.ComponentModel;
using System.Net;

namespace cat.itb.M6UF2EA1
{
    public class AsignaturasCRUD
    {
        static NpgsqlConnection conn;

        public void TestVersion()
        {
            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();
            var sql = "SELECT version()";

            using var cmd = new NpgsqlCommand(sql, conn);

            var version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"PostgreSQL version: {version}");

            conn.Close();
        }

        public void EX1()
        {
            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM alumnos", conn);

            using NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"DNI: {dr[0]} | Apenom: {dr[1]} | Dir: {dr[2]} | Poblacio: {dr[3]} | Telefon: {dr[4]}");
            }

            conn.Close();
        }

        public void EX2()
        {
            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM notas", conn);

            using NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"DNI: {dr[0]} | Cod: {dr[1]} | Nota: {dr[2]}");
            }

            conn.Close();
        }

        public void EX3()
        {
            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM notas WHERE dni = @dni", conn);

            cmd.Parameters.AddWithValue("@dni", "4448242");
            cmd.Prepare();

            using NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"DNI: {dr[0]} | Cod: {dr[1]} | Nota: {dr[2]}");
            }

            conn.Close();
        }

        public void EX4()
        {
            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO alumnos(dni, apenom, direc, pobla, telef) VALUES (@dni, @apenom, @direc, @pobla, @telef) ";

            var alumnos = new[]
            {
                new { Dni = "1111111A", Nombre = "Juan Pérez", Direccion = "Calle Principal 123", Poblacion = "Ciudad A", Telefono = "123456789" },
                new { Dni = "2222222B", Nombre = "María López", Direccion = "Avenida Central 456", Poblacion = "Ciudad B", Telefono = "987654321" },
                new { Dni = "3333333C", Nombre = "Carlos García", Direccion = "Plaza Mayor 789", Poblacion = "Ciudad C", Telefono = "555555555" }
            };

            foreach(var alumno in alumnos)
            {
                cmd.Parameters.Clear(); // Limpiar los parámetros antes de cada inserción

                // Asignar valores de parámetros
                cmd.Parameters.AddWithValue("@dni", alumno.Dni);
                cmd.Parameters.AddWithValue("@apenom", alumno.Nombre);
                cmd.Parameters.AddWithValue("@direc", alumno.Direccion);
                cmd.Parameters.AddWithValue("@pobla", alumno.Poblacion);
                cmd.Parameters.AddWithValue("@telef", alumno.Telefono);

                // Ejecutar el comando de inserción
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }

        public void EX5()
        {
            string[] dnies = { "1111111A", "2222222B", "3333333C" };

            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            foreach (var dni in dnies)
            {
                cmd.Parameters.Clear();

                // CONSEGUIR CODIGO DE FOL
                int codigoFol = 0;
                cmd.CommandText = "SELECT cod FROM asignaturas WHERE nombre = 'FOL'";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal result = reader.GetDecimal(0);
                        codigoFol = Convert.ToInt32(result);
                    }
                }

                cmd.CommandText = "INSERT INTO notas(dni, cod, nota) VALUES (@dni, @asignatura, 8)";
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@asignatura", codigoFol);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                // CONSEGUIR CODIGO DE RET
                int codigoRet = 0;
                cmd.CommandText = "SELECT cod FROM asignaturas WHERE nombre = 'RET'";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal result = reader.GetDecimal(0);
                        codigoRet = Convert.ToInt32(result);
                    }
                }

                cmd.CommandText = "INSERT INTO notas(dni, cod, nota) VALUES (@dni, @asignatura, 8)";
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@asignatura", codigoRet);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }

        public void EX6()
        {
            SchoolConnection db = new SchoolConnection();

            var conn = db.GetConnection();
            var sql = "";

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT dni FROM alumnos WHERE apenom = Cerrato Vela, Luis";
            string dni = "";
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    dni = reader.GetString(0);
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT cod FROM asignaturas WHERE nombre = 'FOL'";
            int codFol = 0;
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    decimal result = reader.GetDecimal(0);
                    codFol = Convert.ToInt32(result);
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE notas SET nota = @nota WHERE dni = @dni AND cod = @cod";
        }
    }
}
