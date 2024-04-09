using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Mapping;
using NHibernate.Properties;

namespace cat.itb.M6UF2Pr.Maps
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orderp");

            Id(x => x.Id);
            Map(x => x.Supplierno);
            References(x => x.Supplier)
                .Column("supplierno")
                .Not.Nullable()
                .Cascade.None();

            Map(x => x.Orderdate);
            Map(x => x.Amount);
            Map(x => x.Deliverydate);
            Map(x => x.Cost);
        }
    }
}
