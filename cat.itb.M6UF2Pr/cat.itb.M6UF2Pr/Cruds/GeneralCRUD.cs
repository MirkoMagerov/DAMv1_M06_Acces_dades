using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Connections;
using Npgsql;

namespace cat.itb.M6UF2Pr.Cruds
{
    public static class GeneralCRUD
    {
        public static void DropTables(List<string> tables)
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

        public static void RunScriptShop()
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

        public static T SelectById<T>(int id) where T : class
        {
            T entity;
            using (var session = SessionFactoryCloud.Open())
            {
                entity = session.Get<T>(id);
            }
            return entity;
        }

        public static List<T> SelectAll<T>() where T : class
        {
            List<T> list;
            using (var session = SessionFactoryCloud.Open())
            {
                list = session.Query<T>().ToList();
            }
            return list;
        }

        public static void Insert<T>(T entity) where T : class
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        tx.Commit();
                        Console.WriteLine($"Registro insertado: {entity}");
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        Console.WriteLine($"ERROR al insertar: {ex.Message}");
                    }
                }
            }
        }

        public static void Update<T>(T entity) where T : class
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        tx.Commit();
                        Console.WriteLine($"Registro actualizado: {entity}");
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        Console.WriteLine($"ERROR al actualizar: {ex.Message}");
                    }
                }
            }
        }

        public static void Delete<T>(T entity) where T : class
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        tx.Commit();
                        Console.WriteLine($"✅ Registro borrado: {entity}");
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        Console.WriteLine($"❎ ERROR al borrar: {ex.Message}");
                    }
                }
            }
        }
    }
}
