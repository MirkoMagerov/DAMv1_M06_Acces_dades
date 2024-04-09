using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr.Maps
{
    internal class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            Table("supplier");

            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.StCode);
            Map(x => x.Zipcode);
            Map(x => x.Area);
            Map(x => x.Phone);
            HasOne(x => x.Product)
               .ForeignKey("productno")
               .Cascade.All()
               .Fetch.Join();

            HasMany(x => x.Orders)
                .KeyColumn("supplierno")
                .Cascade.AllDeleteOrphan()
                .Inverse();

            Map(x => x.Amount);
            Map(x => x.Credit);
            Map(x => x.Remark);
        }
    }
}
