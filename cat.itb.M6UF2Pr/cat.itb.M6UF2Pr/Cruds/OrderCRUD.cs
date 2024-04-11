using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using cat.itb.M6UF2Pr.Model;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class OrderCRUD
    {
        public List<Order> SelectOrderSupplierADO(int supplierId)
        {
            List<Order> orders = new List<Order>(); 
            CloudConnection conn = new CloudConnection();

            using (NpgsqlConnection session = conn.GetConnection())
            {
                string query = "SELECT * FROM orderp WHERE supplierno = @supplierId";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@supplierId", supplierId);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Order order = new Order();
                                order.Supplier = GeneralCRUD.SelectById<Supplier>(supplierId);
                                order.Orderdate = reader.GetDateTime(reader.GetOrdinal("orderdate"));
                                order.Amount = reader.GetInt32(reader.GetOrdinal("amount"));
                                order.Deliverydate = reader.GetDateTime(reader.GetOrdinal("deliverydate"));
                                order.Cost = reader.GetDouble(reader.GetOrdinal("cost"));

                                orders.Add(order);
                            }

                            return orders;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
            }

            return null;
        }
    }
}
