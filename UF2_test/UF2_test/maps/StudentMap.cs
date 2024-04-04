using FluentNHibernate.Mapping;
using UF2_test.model;

namespace UF2_test.maps;
    
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            //Nombre de la tabla en la base de datos
            Table("student");
            //Identificador único, KEY, 
            Id(x => x.id);
            //Mapeamos el apellido dando el apellido que queremos a la columna en la
            //base de datos
            Map(x => x.lastname).Column("lastname");
            //Mapeamos el nombre dando el nombre que queremos a la columna en la
            //base de datos
            Map(x => x.firstname).Column("firstname");
            //Mapeamos la edat dando el nombre que queremos a la columna en la
            //base de datos
            Map(x => x.age).Column("age");
        }
}
