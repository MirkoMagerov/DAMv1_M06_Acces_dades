using cat.itb.M6UF2Pr.Cruds;
using cat.itb.M6UF2Pr.Model;
using System.Security.Cryptography.X509Certificates;

namespace cat.itb.M6UF2Pr
{
    public class Program
    {
        public static void Main()
        {
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

            //GeneralCRUD.DropTables(tables);
            //GeneralCRUD.RunScriptShop();

            //Console.WriteLine(GeneralCRUD.SelectById<Employee>(1));
            //Console.WriteLine(GeneralCRUD.SelectById<Product>(1));
            //Console.WriteLine(GeneralCRUD.SelectById<Supplier>(1));
            //Console.WriteLine(GeneralCRUD.SelectById<Order>(1));

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
                    case 2:
                        EX2();
                        break;
                }
            }

            void EX2()
            {
                Product product1 = productCrud.SelectByCodeADO(100890);
                Product product2 = productCrud.SelectByCodeADO(200376);
                Product product3 = productCrud.SelectByCodeADO(200380);
                Product product4 = productCrud.SelectByCodeADO(100861);

                productCrud.UpdateADO(product1, 8);
                productCrud.UpdateADO(product2, 7);
                productCrud.UpdateADO(product3, 9);
                productCrud.UpdateADO(product4, 12);
            }
        }
    }
}