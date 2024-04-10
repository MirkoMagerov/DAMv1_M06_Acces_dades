using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using cat.itb.M6UF2Pr.Model;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class EmployeeCRUD
    {
        public void InsertADO(List<Employee> employees)
        {
            string query = "INSERT INTO employee (surname, job, managerno, startdate, salary, commission, deptno) VALUES (@surname, @job, @managerno, @startdate, @salary, @commission, @deptno)";

            CloudConnection conn = new CloudConnection();

            using (NpgsqlConnection session = conn.GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        foreach (Employee emp in employees)
                        {
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@surname", emp.Surname);
                            cmd.Parameters.AddWithValue("@job", emp.Job);
                            cmd.Parameters.AddWithValue("@managerno", emp.Managerno);
                            cmd.Parameters.AddWithValue("@startdate", emp.Startdate);
                            cmd.Parameters.AddWithValue("@salary", emp.Salary);
                            cmd.Parameters.AddWithValue("@commission", emp.Commission != null ? emp.Commission : DBNull.Value);
                            cmd.Parameters.AddWithValue("@deptno", emp.Deptno);
                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                        }

                        Console.WriteLine("Empleats inserits correctament");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
            }
        }
    }
}
