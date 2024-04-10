using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Model;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class EmployeeCRUD
    {
        public Employee SelectById(int id)
        {
            Employee emp;
            using (var session = SessionFactoryCloud.Open())
            {
                emp = session.Get<Employee>(id);
            }
            return emp;
        }
    }
}
