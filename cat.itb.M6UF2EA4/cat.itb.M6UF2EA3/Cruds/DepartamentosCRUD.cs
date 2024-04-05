using cat.itb.M6UF2EA3.Model;
using NHibernate;

namespace cat.itb.M6UF2EA3.Cruds
{
    public class DepartamentosCRUD
    {
        public Departamento SelectById(int id)
        {
            Departamento departamento;

            using (var session = SessionFactoryCloud.Open())
            {
                departamento = session.Get<Departamento>(id);
                session.Close();
            }
            return departamento;
        }

        public IList<Departamento> SelectAll()
        {
            IList<Departamento> departamentos;
            using (var session = SessionFactoryCloud.Open())
            {
                departamentos = (from c in session.Query<Departamento>() select c).ToList();
                session.Close();
            }
            return departamentos;
        }

        public void Insert(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(departamento);
                    tx.Commit();
                    Console.WriteLine("Department {0} inserted", departamento.Dnombre);
                    session.Close();
                }
            }
        }

        public void Update(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(departamento);
                        tx.Commit();
                        Console.WriteLine("Department {0} updated", departamento.Id);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        throw new Exception("Error updating department: " + ex.Message);
                    }
                }
                session.Close();
            }
        }

        public void Delete(Departamento department)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(department);
                        tx.Commit();
                        Console.WriteLine("Department {0} deleted", department.Id);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }
                        throw new Exception("Error deleting department: " + ex.Message);
                    }
                }
                session.Close();
            }
        }

        public IList<Departamento> SelectALLHQL()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var hql = "FROM Departamento";

                IQuery query = session.CreateQuery(hql);

                return query.List<Departamento>();
            }
        }
    }
}
