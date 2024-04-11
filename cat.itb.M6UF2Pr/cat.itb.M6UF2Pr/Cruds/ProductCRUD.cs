using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using cat.itb.M6UF2Pr.Model;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class ProductCRUD
    {
        public Product SelectByCodeADO(int code)
        {
            CloudConnection conn = new CloudConnection();
            List<Product> products;

            using (NpgsqlConnection session = conn.GetConnection())
            {
                string query = "SELECT * FROM product WHERE code = @code";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@code", code);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Product product = new Product();
                                product.Code = reader.GetInt32(reader.GetOrdinal("code"));
                                product.Description = reader.GetString(reader.GetOrdinal("description"));
                                product.Currentstock = reader.GetInt32(reader.GetOrdinal("currentstock"));
                                product.Minstock = reader.GetInt32(reader.GetOrdinal("minstock"));
                                product.Price = reader.GetDouble(reader.GetOrdinal("price"));
                                int empNo = reader.GetInt32(reader.GetOrdinal("empno"));
                                product.Employee = GeneralCRUD.SelectById<Employee>(empNo);

                                Console.WriteLine("Product seleccionado correctamente.");

                                return product;
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

        public void UpdateADO(Product product, int stock)
        {
            CloudConnection conn = new CloudConnection();

            using (NpgsqlConnection session = conn.GetConnection())
            {
                string query = "UPDATE product SET currentstock = @stock WHERE code = @code";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@code", product.Code);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine($"Producto actualizado correctamente.");
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
