using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using cat.itb.M6UF2Pr.Model;
using Npgsql;
using System.Security.Cryptography.X509Certificates;

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

                        Console.WriteLine("Empleados insertados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
            }
        }

        public Employee SelectByNameADO(string name)
        {
            CloudConnection conn = new CloudConnection();

            using (NpgsqlConnection session = conn.GetConnection())
            {
                string query = "SELECT * FROM employee WHERE surname LIKE @surname";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@surname", name);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Employee emp = new Employee();
                                emp.Id = reader.GetInt32(reader.GetOrdinal("id"));
                                emp.Surname = reader.GetString(reader.GetOrdinal("surname"));
                                emp.Job = reader.GetString(reader.GetOrdinal("job"));
                                emp.Managerno = reader.GetInt32(reader.GetOrdinal("managerno"));
                                emp.Startdate = reader.GetDateTime(reader.GetOrdinal("startdate"));
                                emp.Salary = reader.GetDouble(reader.GetOrdinal("salary"));
                                emp.Commission = reader.GetDouble(reader.GetOrdinal("commission"));
                                emp.Deptno = reader.GetInt32(reader.GetOrdinal("deptno"));

                                return emp;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }

                    return null;
                }
            }
        }

        public void DeleteADO(Employee emp)
        {
            string query = "DELETE FROM employee WHERE id = @id";

            CloudConnection conn = new CloudConnection();

            using (NpgsqlConnection session = conn.GetConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@id", emp.Id);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine($"Empleado con nombre {emp.Surname} eliminado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
            }
        }

        public Employee SelectByName(string name)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                return session.Query<Employee>().FirstOrDefault(x => x.Surname == name);
            }
        }
    }
}
