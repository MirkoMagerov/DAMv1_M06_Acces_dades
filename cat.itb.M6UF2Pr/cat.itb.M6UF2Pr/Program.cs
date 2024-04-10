using cat.itb.M6UF2Pr.Cruds;
using cat.itb.M6UF2Pr.Model;

namespace cat.itb.M6UF2Pr
{
    public class Program
    {
        public static void Main()
        {
            GeneralCRUD genCrud = new GeneralCRUD();
            EmployeeCRUD empCrud = new EmployeeCRUD();
            ProductCRUD productCrud = new ProductCRUD();
            SupplierCRUD supplierCrud = new SupplierCRUD();
            OrderCRUD orderCrud = new OrderCRUD();

            #region Variables usadas como parametros
            // Nombres tablas
            List<string> tables = ["employee", "product", "supplier", "orderp"];

            // EX 1
            List<Employee> employeesEX1 =
            [
                new Employee {Surname = "SMITH", Job = "DIRECTOR", Managerno = 9, Startdate = new DateTime(1988, 12, 12), Salary = 118000, Commission = 52000, Deptno = 10},
                new Employee {Surname = "JOHNSON", Job = "VENEDOR", Managerno = 4, Startdate = new DateTime(1992, 02, 25), Salary = 125000, Commission = 30000, Deptno = 30},
                new Employee {Surname = "HAMILTON", Job = "ANALISTA", Managerno = 7, Startdate = new DateTime(1989, 03, 18), Salary = 172000, Commission = null, Deptno = 10},
                new Employee {Surname = "JACKSON", Job = "ANALISTA", Managerno = 7, Startdate = new DateTime(2001, 10, 25), Salary = 192000, Commission = null, Deptno = 10}
            ];
            #endregion

            //genCrud.DropTables(tables);
            //genCrud.RunScriptShop();

            bool continuar = true;
            
            while (continuar)
            {
                Console.Write("Introduce el número del ejercicio: ");
                int opcion = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        empCrud.InsertADO(employeesEX1);
                        break;
                }
            }
        }
    }
}