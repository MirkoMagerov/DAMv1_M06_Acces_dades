using NHibernate;
using UF2_test.model;

namespace UF2_test.cruds;

public class StudentCRUD
{
    
    public Student SelectById(int Id)
    {
        Student student;
        using (var session = SessionFactoryCloud.Open())
        {
            student = session.Get<Student>(Id);
            session.Close();
        }

        return student;
    }
    
    public IList<Student> SelectByName(string name)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            // IQuery query = session.CreateQuery("select * from student c where c.firstname = 'Roc'");
            IQuery query = session.CreateQuery("select c from Student c where c.firstname = " +"'" + name +"'");
            students = query.List<Student>();
           
            session.Close();
        }

        return students;
    }
    
    public IList<Student> SelectAll()
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            students = (from c in session.Query<Student>() select c).ToList();
            session.Close();
        }
        return students;
    }
    public void Insert(Student student)
    {
        using (var session = SessionFactoryCloud.Open())
        {
            using (var tx = session.BeginTransaction())
            {
                session.Save(student);
                tx.Commit();
                Console.WriteLine("Student {0} inserted",student.lastname);
                session.Close();
            }
        }
    }
    
    public void Update(Student student)
    {
        using (var session = SessionFactoryCloud.Open())
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                   session.Update(student);
                    tx.Commit();
                   Console.WriteLine("Student {0} updated",student.lastname);
                }
                catch (Exception ex)
                {
                    if (!tx.WasCommitted)
                    {
                        tx.Rollback();
                    }
                    throw new Exception("Error updating student : " + ex.Message);
                }
            }
            session.Close();
        }
    }
    public void Delete(Student student)
    {
        using (var session = SessionFactoryCloud.Open())
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Delete(student);
                    tx.Commit();
                   Console.WriteLine("Student {0} deleted",student.lastname);
                }
                catch (Exception ex)
                {
                    if (!tx.WasCommitted)
                    {
                        tx.Rollback();
                    }
                    throw new Exception("Error deleting student : " + ex.Message);
                }
            }
            session.Close();
        }
    }
}