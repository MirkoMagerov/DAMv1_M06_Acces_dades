using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Model;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class SupplierCRUD
    {
        public Supplier SelectById(int id)
        {
            Supplier supplier;
            using (var session = SessionFactoryCloud.Open())
            {
                supplier = session.Get<Supplier>(id);
            }
            return supplier;
        }
    }
}
