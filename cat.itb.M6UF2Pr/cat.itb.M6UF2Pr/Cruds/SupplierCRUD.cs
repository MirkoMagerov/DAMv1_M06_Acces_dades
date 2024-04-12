using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using cat.itb.M6UF2Pr.Model;
using NHibernate.Criterion;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class SupplierCRUD
    {
        public List<Supplier> SelectCreditHigherThanADO(double credit)
        {
            CloudConnection conn = new CloudConnection();
            List<Supplier> suppliers = new List<Supplier>();

            using (NpgsqlConnection session = conn.GetConnection())
            {
                string query = "SELECT * FROM supplier WHERE credit > @credit";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, session))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@credit", credit);
                        cmd.Prepare();

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Supplier supplier = new Supplier();
                                supplier.Name = reader.GetString(reader.GetOrdinal("name"));
                                supplier.Address = reader.GetString(reader.GetOrdinal("address"));
                                supplier.City = reader.GetString(reader.GetOrdinal("city"));
                                supplier.StCode = reader.GetString(reader.GetOrdinal("stcode"));
                                supplier.Zipcode = reader.GetString(reader.GetOrdinal("zipcode"));
                                supplier.Area = reader.GetInt32(reader.GetOrdinal("area"));
                                supplier.Phone = reader.GetString(reader.GetOrdinal("phone"));
                                supplier.Product = GeneralCRUD.SelectById<Product>(reader.GetInt32(reader.GetOrdinal("productno")));
                                supplier.Amount = reader.GetInt32(reader.GetOrdinal("amount"));
                                supplier.Credit = reader.GetDouble(reader.GetOrdinal("credit"));
                                supplier.Remark = reader.GetString(reader.GetOrdinal("remark"));

                                suppliers.Add(supplier);
                            }

                            return suppliers;
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

        public List<Supplier> SelectByCity(string city)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                return session.Query<Supplier>().Where(x => x.City == city).ToList();
            }
        }

        public Supplier SelectLowestAmount()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                int minAmount = session.QueryOver<Supplier>()
                                        .Select(Projections.Min<Supplier>(s => s.Amount))
                                        .SingleOrDefault<int>();

                Supplier lowestSupplier = session.QueryOver<Supplier>()
                                                 .Where(s => s.Amount == minAmount)
                                                 .SingleOrDefault();

                return lowestSupplier;
            }
        }
    }
}
