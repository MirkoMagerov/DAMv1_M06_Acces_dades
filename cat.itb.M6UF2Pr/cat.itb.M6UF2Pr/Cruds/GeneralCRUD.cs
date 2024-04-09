using cat.itb.M6UF2Pr.Connections;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class GeneralCRUD
    {
        public void DropTables(List<string> tables)
        {
            CloudConnection db = new CloudConnection();

            using (var conn = db.GetConnection())
            {
                foreach (var table in tables)
                {
                    var cmd = new NpgsqlCommand("DROP TABLE " + table + " CASCADE", conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Table {0} succesfully deleted", table);
                    }
                    catch
                    {
                        Console.WriteLine("Table {0} doesn't exist", table);
                    }

                }
            }
        }

        public void RunScriptShop()
        {
            CloudConnection db = new CloudConnection();
            var conn = db.GetConnection();

            string script = File.ReadAllText(@"..\..\..\Fichers\shop.sql");
            var cmd = new NpgsqlCommand(script, conn);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Script executed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            conn.Close();
        }
    }
}
