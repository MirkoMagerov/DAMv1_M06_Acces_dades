using cat.itb.M6UF2EA3.Model;

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
    }
}
