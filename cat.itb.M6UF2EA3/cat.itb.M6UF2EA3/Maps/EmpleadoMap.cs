using cat.itb.M6UF2EA3.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2EA3.Maps
{
    public class EmpleadoMap : ClassMap<Empleado>
    {
        public EmpleadoMap()
        {
            // Nombre tabla
            Table("empleados");

            //Identificador único
            Id(x => x.Id);

            // Mapeo
            Map(x => x.Empno).Column("empno");

            Map(x => x.Apellido).Column("apellido");

            Map(x => x.Oficio).Column("oficio");

            Map(x => x.Dir).Column("dir");

            Map(x => x.Fechaalt).Column("fechaalt");

            Map(x => x.Salario).Column("salario");

            Map(x => x.Comision).Column("comision");

            Map(x => x.Deptno).Column("deptno");
        }
    }
}
