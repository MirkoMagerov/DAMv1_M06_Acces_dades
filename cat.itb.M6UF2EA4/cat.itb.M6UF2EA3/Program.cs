using cat.itb.M6UF2EA3.Cruds;
using cat.itb.M6UF2EA3.Model;
using NHibernate;
using NHibernate.Criterion;

namespace cat.itb.M6UF2EA3
{
    class Program
    {
        public static void Main()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Ejecutar EX1()");
                Console.WriteLine("2. Ejecutar EX2()");
                Console.WriteLine("3. Ejecutar EX3()");
                Console.WriteLine("4. Ejecutar EX4()");
                Console.WriteLine("5. Ejecutar EX5()");
                Console.WriteLine("6. Ejecutar EX6()");
                Console.WriteLine("7. Ejecutar EX7()");
                Console.WriteLine("8. Ejecutar EX8()");
                Console.WriteLine("9. Ejecutar EX9()");
                Console.WriteLine("10. Ejecutar EX10()");
                Console.WriteLine("0. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        EX1();
                        break;
                    case "2":
                        EX2();
                        break;
                    case "3":
                        EX3();
                        break;
                    case "4":
                        EX4();
                        break;
                    case "5":
                        EX5();
                        break;
                    case "6":
                        EX6();
                        break;
                    case "7":
                        EX7();
                        break;
                    case "8":
                        EX8();
                        break;
                    case "9":
                        EX9();
                        break;
                    case "10":
                        EX10();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void EX1()
        {
            DepartamentosCRUD depCRUD = new DepartamentosCRUD();

            IList<Departamento> deps = depCRUD.SelectALLHQL();

            foreach(Departamento dep in deps)
            {
                Console.WriteLine(dep.ToString());
            }
        }

        public static void EX2()
        {
            EmpleadosCRUD empCRUD = new EmpleadosCRUD();

            IList<Empleado> emps = empCRUD.SelectAllCriteria();

            foreach (Empleado emp in emps)
            {
                Console.WriteLine(emp.ToString());
            }
        }

        public static void EX3()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                ICriteria criteria = session.CreateCriteria<Empleado>()
                        .Add(Restrictions.Ge("Salario", 2000.00));

                IList<Empleado> emps = criteria.List<Empleado>();

                Console.WriteLine("Empleados que cobran más de 2000: ");
                Console.WriteLine();
                foreach (Empleado emp in emps)
                {
                    Console.WriteLine($"Apellido: {emp.Apellido} | Salario: {emp.Salario}");
                    Console.WriteLine();
                }
            }
        }

        public static void EX4()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var hql = "FROM Departamento WHERE Dnombre = 'VENTAS'";

                IQuery query = session.CreateQuery(hql);

                var deps = query.List<Departamento>();

                foreach(Departamento dep in deps)
                {
                    Console.WriteLine(dep.ToString());
                }
            }
        }

        public static void EX5()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var emps = session.QueryOver<Empleado>()
                                  .Where(e => e.Oficio == "VENDEDOR")
                                  .OrderBy(e => e.Salario).Desc
                                  .List();

                Console.WriteLine("Empleados que son venedores: ");
                Console.WriteLine();
                foreach (Empleado emp in emps)
                {
                    Console.WriteLine(emp.ToString());
                    Console.WriteLine();
                }
            }
        }

        public static void EX6()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var hql = "FROM Empleado WHERE LEFT(APELLIDO, 1) = 'S'";

                IQuery query = session.CreateQuery(hql);

                var emps = query.List<Empleado>();

                Console.WriteLine("Empleados que su apellido comienza por 'S':");
                Console.WriteLine();
                foreach (Empleado emp in emps)
                {
                    Console.WriteLine($"Apellido: {emp.Apellido} | Oficio: {emp.Oficio} | Salario: {emp.Salario}");
                    Console.WriteLine();
                }
            }
        }

        public static void EX7()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var deps = session.QueryOver<Departamento>()
                                  .Where(d => d.Loc == "SEVILLA" || d.Loc == "BARCELONA")
                                  .List();

                Console.WriteLine("Departamentos de Sevilla o Barcelona:");
                Console.WriteLine();
                foreach (Departamento dep in deps)
                {
                    Console.WriteLine(dep.ToString());
                    Console.WriteLine();
                }
            }
        }

        public static void EX8()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var emps = session.QueryOver<Empleado>()
                                  .Where(e => e.Salario > 2000 && e.Salario < 3500)
                                  .OrderBy(e => e.Apellido).Asc
                                  .List();

                Console.WriteLine("Empleados cobran entre 2000 y 3500: ");
                Console.WriteLine();
                foreach (Empleado emp in emps)
                {
                    Console.WriteLine(emp.Apellido);
                    Console.WriteLine();
                }
            }
        }

        public static void EX9()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var emps = session.QueryOver<Empleado>()
                                  .Where(e => e.Salario > 1400 && e.Oficio == "EMPLEADO")
                                  .List();

                Console.WriteLine("Empleados que cobran más de 1400 y su oficio es EMPLEADO: ");
                Console.WriteLine();
                foreach (Empleado emp in emps)
                {
                    Console.WriteLine($"Apellido: {emp.Apellido} | Salario: {emp.Salario}");
                    Console.WriteLine();
                }
            }
        }

        public static void EX10()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                QueryOver<Empleado> empleado = QueryOver.Of<Empleado>()
                                                        .SelectList(p => p.SelectMax(c => c.Salario));

                IList<Empleado> maxSalaryEmps = session.QueryOver<Empleado>()
                                                    .Where(Subqueries.WhereProperty<Empleado>(c => c.Salario).Eq(empleado))
                                                    .List();

                foreach(Empleado emp in maxSalaryEmps)
                {
                    Console.WriteLine(emp.ToString());
                }
            }
        }
    }
}
