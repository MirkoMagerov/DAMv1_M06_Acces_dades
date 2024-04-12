using cat.itb.M6UF2Pr.Cruds;
using cat.itb.M6UF2Pr.Model;
using System;
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

            // Nombres tablas
            List<string> tables = ["employee", "product", "supplier", "orderp"];

            // EX 1
            List<Employee> employeesEX1 =
            [
                new Employee { Surname = "SMITH", Job = "DIRECTOR", Managerno = 9, Startdate = new DateTime(1988, 12, 12), Salary = 118000, Commission = 52000, Deptno = 10 },
                new Employee { Surname = "JOHNSON", Job = "VENEDOR", Managerno = 4, Startdate = new DateTime(1992, 02, 25), Salary = 125000, Commission = 30000, Deptno = 30 },
                new Employee { Surname = "HAMILTON", Job = "ANALISTA", Managerno = 7, Startdate = new DateTime(1989, 03, 18), Salary = 172000, Commission = null, Deptno = 10 },
                new Employee { Surname = "JACKSON", Job = "ANALISTA", Managerno = 7, Startdate = new DateTime(2001, 10, 25), Salary = 192000, Commission = null, Deptno = 10 }
            ];

            bool continuar = true;

            while (continuar)
            {
                Console.Write("Introduce el número del ejercicio: ");
                int opcion = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcion)
                {
                    case -1:
                        GeneralCRUD.DropTables(tables);
                        break;
                    case 0:
                        GeneralCRUD.RunScriptShop();
                        break;
                    case 1:
                        empCrud.InsertADO(employeesEX1);
                        break;
                    case 2:
                        EX2();
                        break;
                    case 3:
                        EX3();
                        break;
                    case 4:
                        EX4();
                        break;
                    case 5:
                        empCrud.DeleteADO(empCrud.SelectByNameADO("SMITH"));
                        break;
                    case 6:
                        EX6();
                        break;
                    case 7:
                        EX7();
                        break;
                    case 8:
                        EX8();
                        break;
                    case 9:
                        EX9();
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

                Console.WriteLine();
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

            void EX3()
            {
                const int supplierId = 6;
                List<Order> orders = orderCrud.SelectOrderSupplierADO(supplierId);
                double costTotal = orders.Sum(x => x.Cost * x.Amount);
                double quantitat = orders.Sum(x => x.Amount);
                Console.WriteLine($"El proveïdor amb id {supplierId} ha facturat un total de {costTotal} per una quantitat igual a {quantitat}.");
            }

            void EX4()
            {
                const int creditAmount = 8000;
                List<Supplier> suppliers = supplierCrud.SelectCreditHigherThanADO(creditAmount);
                Console.WriteLine($"Proveïdors que tenen un credit superior a {creditAmount}: ");
                Console.WriteLine();
                foreach (Supplier supplier in suppliers)
                {
                    Console.WriteLine(supplier);
                    Console.WriteLine();
                }
            }

            void EX6()
            {
                var product1 = new Product()
                {
                    Code = 900001,
                    Description = "GALLETITAS",
                    Currentstock = 13,
                    Minstock = 3,
                    Price = 7.2,
                    Employee = GeneralCRUD.SelectById<Employee>(5)
                };
                var product2 = new Product()
                {
                    Code = 900002,
                    Description = "CHOCOLATE",
                    Currentstock = 15,
                    Minstock = 7,
                    Price = 9.42,
                    Employee = GeneralCRUD.SelectById<Employee>(7)
                };

                GeneralCRUD.Insert(product1);
                GeneralCRUD.Insert(product2);

                var supplier1 = new Supplier()
                {
                    Name = "Supplier1",
                    Address = "123 Main Street",
                    City = "City1",
                    StCode = "SE",
                    Zipcode = "12345",
                    Area = 100,
                    Phone = "123-456",
                    Amount = 30,
                    Credit = 70.300,
                    Remark = "Some remarks",
                    Product = GeneralCRUD.SelectById<Product>(product1.Id)
                };
                var supplier2 = new Supplier()
                {
                    Name = "Supplier2",
                    Address = "321 Main Street",
                    City = "City2",
                    StCode = "SO",
                    Zipcode = "12345",
                    Area = 50,
                    Phone = "123-456",
                    Amount = 35,
                    Credit = 30.220,
                    Remark = "Some remarks",
                    Product = GeneralCRUD.SelectById<Product>(product2.Id)
                };

                GeneralCRUD.Insert(supplier1);
                GeneralCRUD.Insert(supplier2);
            }

            void EX7()
            {
                List<Supplier> suppliers = supplierCrud.SelectByCity("BURLINGAME");
                foreach (Supplier supplier in suppliers)
                {
                    supplier.Credit = 10000;
                    GeneralCRUD.Update(supplier);
                }
            }

            void EX8()
            {
                List<Product> products = GeneralCRUD.SelectAll<Product>();
                Console.WriteLine("TODOS LOS PRODUCTOS: ");
                Console.WriteLine();
                foreach (Product product in products)
                {
                    Console.WriteLine(product);
                    Console.WriteLine();
                }
            }

            void EX9()
            {
                Employee emp = empCrud.SelectByName("ARROYO");

                foreach (Product prod in emp.Products)
                {
                    Console.WriteLine($"Proveedor del producto {prod.Description}: {prod.Supplier.Name}");
                }
            }

            void EX10()
            {
                List<Order> orders = orderCrud.SelectByCostHigherThan(10000, 100);
                foreach (Order order in orders)
                {
                    Console.WriteLine(order);
                    Console.WriteLine();
                }
            }
        }
    }
}