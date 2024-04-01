using Npgsql;

namespace cat.itb.M6UF2EA2.Cruds
{
    public class GeneralCRUD
    {
        public NpgsqlConnection NpgsqlConnection { get; set; }
        public CloudConnection CloudConnection { get; set; }

        public GeneralCRUD()
        {
            CloudConnection cloudConnection = new CloudConnection();
            NpgsqlConnection = cloudConnection.NpgsqlConnection();
        }

        public void DropTables(List<string> tables)
        {
            using (var conn = NpgsqlConnection)
            {
                conn.Open();
                try
                {
                    foreach(string table in tables)
                    {
                        string dropTable = $"DROP TABLE IF EXISTS {table} CASCADE;";
                        using (var command = new NpgsqlCommand(dropTable, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("Todas las tablas fueron eliminadas correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar las tablas: {ex.Message}");
                }
                finally
                {
                    NpgsqlConnection.Close();
                }
            }
        }

        public void RunScriptEmpresa()
        {
            string filePath = @"..\..\..\Empresa.sql";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("El archivo SQL especificado no existe.");
                return;
            }

            string sqlScript = File.ReadAllText(filePath);

            try
            {
                NpgsqlConnection.Open();
                using (var command = new NpgsqlCommand(sqlScript, NpgsqlConnection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Script ejecutado correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el script SQL: {ex.Message}");
            }
            finally
            {
                NpgsqlConnection.Close();
            }
        }
    }
}
