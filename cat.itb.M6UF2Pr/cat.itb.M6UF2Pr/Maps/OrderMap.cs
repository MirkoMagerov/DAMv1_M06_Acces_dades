using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr.Maps
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orderp");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Orderdate);
            Map(x => x.Amount);
            Map(x => x.Deliverydate);
            Map(x => x.Cost);

            References(x => x.Supplier, "supplierno")
                .Not.LazyLoad()
                .Cascade.AllDeleteOrphan()
                .Fetch.Join();
        }
    }
}
