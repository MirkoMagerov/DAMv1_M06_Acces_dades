using cat.itb.M6UF2Pr.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr.Maps
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("employee");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Surname).Column("surname");
            Map(x => x.Job).Column("job");
            Map(x => x.Managerno).Column("managerno");
            Map(x => x.Startdate).Column("startdate");
            Map(x => x.Salary).Column("salary");
            Map(x => x.Commission).Column("commission");
            Map(x => x.Deptno).Column("deptno");
            HasMany(x => x.Products)
                .KeyColumn("empno")
                .Not.LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .Fetch.Join()
                .AsSet();
        }
    }
}
