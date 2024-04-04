using Npgsql;

namespace UF2_test.cruds;

public class GeneralCRUD
{
    
    public void RunScriptStudent()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        string script = File.ReadAllText("../../../files/student.sql");
        var cmd = new NpgsqlCommand(script, conn);
        try
        {
            cmd.ExecuteNonQuery();
            Console.WriteLine("Script executed successfully");
        }
        catch
        {
            Console.WriteLine("Couldn't execute script, try to execute option 12 and then 11 again");
        }
            
        conn.Close();
    }
}
    
