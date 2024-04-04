using cat.itb.M6UF2EA3.Cruds;
using cat.itb.M6UF2EA3.Model;

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
            Console.WriteLine("Ejecutando EX1.");
            DepartamentosCRUD depCrud = new DepartamentosCRUD();
            Departamento dep1 = new Departamento
            {
                Dnombre = "TECNOLOGIA",
                Loc = "BARCELONA"
            };
            Departamento dep2 = new Departamento
            {
                Dnombre = "INFORMATICA",
                Loc = "SEVILLA"
            };

            try
            {
                depCrud.Insert(dep1);
                depCrud.Insert(dep2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX2()
        {
            Console.WriteLine("Ejecutando EX2.");
            EmpleadosCRUD empCrud = new EmpleadosCRUD();
            DepartamentosCRUD depCrud = new DepartamentosCRUD();

            Empleado emp1 = new Empleado
            {
                Empno = 1,
                Apellido = "Garcia",
                Oficio = "Programador",
                Dir = 101,
                Fechaalt = new DateTime(2018, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                Salario = 5000,
                Comision = 20,
                Departamento = depCrud.SelectById(7)
            };

            Empleado emp2 = new Empleado
            {
                Empno = 2,
                Apellido = "Martinez",
                Oficio = "Diseñador",
                Dir = 102,
                Fechaalt = new DateTime(2018, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                Salario = 4500,
                Comision = 18,
                Departamento = depCrud.SelectById(8)
            };

            try
            {
                empCrud.Insert(emp1);
                empCrud.Insert(emp2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX3()
        {
            Console.WriteLine("Ejecutando EX3.");
            DepartamentosCRUD depCrud = new DepartamentosCRUD();

            try
            {
                Departamento departamento = depCrud.SelectById(2);
                departamento.Dnombre = "RECERCA";
                depCrud.Update(departamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX4()
        {
            Console.WriteLine("Ejecutando EX4.");
            EmpleadosCRUD empCRUD = new EmpleadosCRUD();

            try
            {
                var allEmps = empCRUD.SelectAll();
                Empleado emp = allEmps.First(x => x.Empno == 7499);

                emp.Salario = 2100;
                empCRUD.Update(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX5()
        {
            Console.WriteLine("Ejecutando EX5.");
            EmpleadosCRUD empCRUD = new EmpleadosCRUD();

            try
            {
                var allEmps = empCRUD.SelectAll();
                Empleado emp = allEmps.First(x => x.Apellido == "SALA");

                empCRUD.Delete(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX6()
        {
            Console.WriteLine("Ejecutando EX6.");
            EmpleadosCRUD empCRUD = new EmpleadosCRUD();

            try
            {
                var allEmps = empCRUD.SelectAll().Where(x => x.Salario > 2000);
                Console.WriteLine("Empleados que cobran más de 2000: ");
                foreach (Empleado emp in allEmps)
                {
                    Console.WriteLine($"Apellido: {emp.Apellido} | Salario: {emp.Salario}.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX7()
        {
            Console.WriteLine("Ejecutando EX7.");
            EmpleadosCRUD empCRUD = new EmpleadosCRUD();

            try
            {
                Departamento dep = empCRUD.SelectById(6).Departamento;

                Console.WriteLine($"Nombre del departamento del empleado con ID 6: {dep.Dnombre}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EX8()
        {
            Console.WriteLine("Ejecutando EX8.");
            DepartamentosCRUD depCRUD = new DepartamentosCRUD();

            try
            {
                IList<Empleado> empleados = depCRUD.SelectById(2).Empleados;
                Console.WriteLine("Empleados del departamento con ID 2: ");
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine($"Apellido: {empleado.Apellido} | Oficio: {empleado.Oficio} | Salario: {empleado.Salario}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
