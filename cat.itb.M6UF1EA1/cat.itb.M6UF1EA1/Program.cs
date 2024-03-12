using cat.itb.M6UF1EA1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace M6
{
    public class Program
    {
        public static void Main()
        {
            string rutaPruebas = @"D:\MiroslavMagerov\DAMv1_M06_Acces_dades\Pruebas\";
            string rutaRelativaFiles = @"..\..\..\files\";

            ReadJsonFile(rutaRelativaFiles + "products1.json");
        }

        public static Product CreateProduct(string name, double price, int stock, string picture, string[] categories)
        {
            return new Product(name, price, stock, picture, categories);
        }

        public static void ReadJsonFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    Product product = JsonConvert.DeserializeObject<Product>(line);
                    string productJson = JsonConvert.SerializeObject(product);
                    Console.WriteLine(productJson);
                }
            }
        }

        public static void WriteJsonFile(string path, Product[] products)
        {
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                foreach (Product product in products)
                {
                    string productJson = JsonConvert.SerializeObject(product);
                    sw.WriteLine(productJson);
                }
            }
        }

        public static void WriteFiveProducts(string path)
        {
            Product product1 = CreateProduct("Ps5", 499.99, 10, "ps5_picture.jpg", new string[] { "Electronics", "Gaming" });
            Product product2 = CreateProduct("Headphones", 79.99, 20, "headphones_picture.jpg", new string[] { "Electronics", "Audio" });
            Product product3 = CreateProduct("Smartwatch", 199.99, 15, "smartwatch_picture.jpg", new string[] { "Electronics", "Wearable" });
            Product product4 = CreateProduct("Backpack", 49.99, 30, "backpack_picture.jpg", new string[] { "Fashion", "Accessories" });
            Product product5 = CreateProduct("Book", 12.99, 50, "book_picture.jpg", new string[] { "Books", "Education" });
            
            Product[] products = new Product[] { product1, product2, product3, product4, product5 };

            WriteJsonFile(path, products);
        }
    }
}