using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr.Maps
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("product");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Code);
            Map(x => x.Description);
            Map(x => x.Currentstock);
            Map(x => x.Minstock);
            Map(x => x.Price);
            Map(x => x.Empno);
            HasOne(x => x.Employee)
                .ForeignKey("empno")
                .Not.LazyLoad()
                .Cascade.All()
                .Fetch.Join();

            HasOne(x => x.Supplier)
                .ForeignKey("")
                .Not.LazyLoad()
                .Cascade.All()
                .Fetch.Join();
        }
    }
}
