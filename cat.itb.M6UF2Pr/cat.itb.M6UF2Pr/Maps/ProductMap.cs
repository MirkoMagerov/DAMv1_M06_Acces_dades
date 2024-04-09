using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr.Maps
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("orderp");

            Id(x => x.Id);

            Map(x => x.Code);
            Map(x => x.Description);
            Map(x => x.Currentstock);
            Map(x => x.Minstock);
            Map(x => x.Price);
            Map(x => x.Empno);

            HasOne(x => x.Employee)
                .ForeignKey("empno")
                .Cascade.All()
                .Not.LazyLoad()
                .Fetch.Join();

            References(x => x.Supplier)
                .Column("supplierid")
                .Cascade.All()
                .Fetch.Join();
        }
    }
}
