using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using cat.itb.M6UF2Pr.Model;
using NHibernate;
using NHibernate.Criterion;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class OrderCRUD
    {
        public List<Model.Order> SelectOrderSupplierADO(int supplierId)
        {
            List<Model.Order> orders = new List<Model.Order>(); 
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
                                Model.Order order = new Model.Order();
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

        public List<Model.Order> SelectByCostHigherThan(int cost, int quantity)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                ICriteria criteria = session.CreateCriteria<Model.Order>();

                criteria.Add(Restrictions.Gt("Cost", cost));
                criteria.Add(Restrictions.Eq("Quantity", quantity));

                IList<Model.Order> orders = criteria.List<Model.Order>();

                return new List<Model.Order>(orders);
            }
        }
    }
}
