using cat.itb.M6UF2EA3.Model;
using NHibernate;
using NHibernate.Criterion;

namespace cat.itb.M6UF2EA3.Cruds
{
    public class EmpleadosCRUD
    {
        public Empleado SelectById(int id)
        {
            Empleado empleado;
            using (var session = SessionFactoryCloud.Open())
            {
                empleado = session.Get<Empleado>(id);
                session.Close();
            }
            return empleado;
        }

        public IList<Empleado> SelectAll()
        {
            IList<Empleado> empleados;
            using (var session = SessionFactoryCloud.Open())
            {
                empleados = (from c in session.Query<Empleado>() select c).ToList();
                session.Close();
            }
            return empleados;
        }

        public void Insert(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(empleado);
                    tx.Commit();
                    Console.WriteLine("Employee {0} inserted", empleado.Apellido);
                    session.Close();
                }
            }
        }

        public void Update(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(empleado);
                        tx.Commit();
                        Console.WriteLine("Employee {0} updated", empleado.Apellido);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        throw new Exception("Error updating employee: " + ex.Message);
                    }
                }
                session.Close();
            }
        }

        public void Delete(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(empleado);
                        tx.Commit();
                        Console.WriteLine("Employee {0} deleted", empleado.Apellido);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        throw new Exception("Error deleting employee : " + ex.Message);
                    }
                }
                session.Close();
            }
        }

        public IList<Empleado> SelectAllCriteria()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                ICriteria criteria = session.CreateCriteria<Empleado>();

                return criteria.List<Empleado>();
            }
        }
    }
}
