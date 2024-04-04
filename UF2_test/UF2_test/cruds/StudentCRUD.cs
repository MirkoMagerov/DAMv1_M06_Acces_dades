using NHibernate;
using NHibernate.Criterion;
using UF2_test.model;

namespace UF2_test.cruds;

public class StudentCRUD
{
    
    public Student SelectById(int pId)
    {
        Student student;
        using (var session = SessionFactoryCloud.Open())
        {
            student = session.Get<Student>(pId);
            session.Close();
        }

        return student;
    }
    
    
    public void Insert(Student pStudent)
    {
        using (var session = SessionFactoryCloud.Open())
        {
            using (var tx = session.BeginTransaction())
            {
                session.Save(pStudent);
                tx.Commit();
                Console.WriteLine("Student {0} inserted",pStudent.lastname);
                session.Close();
            }
        }
    }
    
    public void Update(Student pStudent)
    {
        using (var session = SessionFactoryCloud.Open())
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                   session.Update(pStudent);
                    tx.Commit();
                   Console.WriteLine("Student {0} updated",pStudent.lastname);
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
    public void Delete(Student pStudent)
    {
        using (var session = SessionFactoryCloud.Open())
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Delete(pStudent);
                    tx.Commit();
                   Console.WriteLine("Student {0} deleted",pStudent.lastname);
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
    
    public IList<Student> SelectAllNativeSQL()
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            IQuery sqlQuery = session.CreateSQLQuery("SELECT * FROM student").AddEntity(typeof(Student));
            students= sqlQuery.List<Student>();
            session.Close();
        }
        return students;
    }
    
    public IList<Student> SelectByNameNativeSQL(string pName)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {

           students = session.CreateSQLQuery("SELECT * FROM student WHERE firstname like " + "'" + pName + "'").AddEntity(typeof(Student)).List<Student>(); 

           session.Close();
        }

        return students;
    }
    public IList<Student> SelectAllHQL()
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            IQuery query = session.CreateQuery("select c from Student c");
            students = query.List<Student>();
            
            session.Close();
        }
        return students;
    }
    
    public IList<Student> SelectByNameHQL(string pName)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            IQuery query = session.CreateQuery("select c from Student c where c.firstname = " +"'" + pName +"'");
            students = query.List<Student>();
           
            session.Close();
        }

        return students;
    }
    
    public IList<Student> SelectByLastNameStartsByHQL(string pLetter)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            IQuery query = session.CreateQuery("select c from Student c where c.lastname like " +"'" + pLetter + "%" + "'");
            students = query.List<Student>();
           
            session.Close();
        }

        return students;
    }
    
    public IList<Student> SelectAllCriteria()
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            ICriteria crit = session.CreateCriteria<Student>();
            crit.SetMaxResults(50);
            students = crit.List<Student>();
            session.Close();
        }
        return students;
    }


    public IList<Student> SelectByNameCriteria(string pName)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            students = session.CreateCriteria<Student>() 
                .Add(Restrictions.Eq("firstname", pName)).List<Student>(); 
           
            session.Close();
        }

        return students;
    }
    
    public IList<Student> SelectByLastNameCriteria(string pLastName)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            students= session.CreateCriteria<Student>()
                .Add( Expression.Like("lastname", pLastName) )
                .List<Student>();
            session.Close();
        }

        return students;
    }
    
    public IList<Student> SelectByLastNameStartsByCriteria(string pLetter)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            students = session.CreateCriteria<Student>() 
                .Add(Restrictions.Like("lastname", pLetter + "%")).List<Student>(); 
            
            session.Close();
        }

        return students;
    }
    public IList<Student> SelectAllLinq()
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            students = (from c in session.Query<Student>() select c).ToList();
            session.Close();
        }
        return students;
    }
    
    public  IList<Student> SelectByLastNameLinq(string pLastName)
    {
        IList<Student> students; 
        using (var session = SessionFactoryCloud.Open())
        {
            students = session.Query<Student>().Where(c => c.lastname == pLastName).ToList();
            session.Close();
        }
        return students;
    }
    
    public  Student SelectByLastNameLinq2(string pLastName)
    {
        Student student; 
        using (var session = SessionFactoryCloud.Open())
        {
            student = session.Query<Student>().Where(c => c.lastname == pLastName).First();
            session.Close();
        }
        return student;
    }
    
    public IList<Student> SelectByLastNameStartsByLinq(string pLetter)
    {
        IList<Student> students; 
        using (var session = SessionFactoryCloud.Open())
        {
            
            students = session.Query<Student>().Where(c => c.lastname.StartsWith(pLetter)).ToList();
            session.Close();
        }
        return students;
    }
    
    
    public IList<Student> SelectAllQueryOver()
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
           students = session.QueryOver<Student>()
                    .List();
            session.Close();
        }
        return students;
    }
    
    public IList<Student> SelectByAgeIntervalQueryOver(int pAge1, int pAge2)
    {
        IList<Student> students;
        using (var session = SessionFactoryCloud.Open())
        {
            students =
                session.QueryOver<Student>()
                    .WhereRestrictionOn(c => c.age).IsBetween(pAge1).And(pAge2)
                    .OrderBy(c => c.age).Asc
                    .List<Student>();
            
            session.Close();
        }
        return students;
    }
    
    public IList<String> SelectByAgeGreatToQueryOver(int pAge)
    {
        IList<String> studentNames;
        using (var session = SessionFactoryCloud.Open())
        {
   
            studentNames =
                session.QueryOver<Student>()
                    .Where(c => c.age > pAge)
                    .Select(c => c.firstname)
                    .OrderBy(c => c.firstname).Asc
                    .List<String>();
          
            session.Close();
        }
        return studentNames;
    }
   
    public IList<Student> SelectOldestQueryOver()
    {
        IList<Student> oldestStudents;
        using (var session = SessionFactoryCloud.Open())
        {
     
            QueryOver<Student> maximumAge =
                QueryOver.Of<Student>()
                    .SelectList(p => p.SelectMax(c => c.age));
            
            oldestStudents =
                session.QueryOver<Student>()
                    .Where(Subqueries.WhereProperty<Student>(c => c.age).Eq(maximumAge))
                    .List();
            
            /*
            oldestStudents =
                session.QueryOver<Student>()
                    .WithSubquery.WhereProperty(c => c.age).Eq(maximumAge)
                    .List();            
            */

            session.Close();
        }
        return oldestStudents;
    }
    
}


