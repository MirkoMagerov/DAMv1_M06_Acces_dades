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
            Map(x => x.Surname);
            Map(x => x.Job);
            Map(x => x.Managerno);
            Map(x => x.Startdate);
            Map(x => x.Salary);
            Map(x => x.Commission);
            Map(x => x.Deptno);

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
