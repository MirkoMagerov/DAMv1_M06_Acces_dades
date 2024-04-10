using cat.itb.M6UF2EA3;
using cat.itb.M6UF2Pr.Model;

namespace cat.itb.M6UF2Pr.Cruds
{
    public class ProductCRUD
    {
        public Product SelectById(int id)
        {
            Product product;
            using (var session = SessionFactoryCloud.Open())
            {
                product = session.Get<Product>(id);
            }
            return product;
        }
    }
}
