using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;

namespace cat.itb.M6UF1EA2
{
    public class Program
    {
        public static void Main()
        {
            const string FilesPath = @"..\..\..\files\";
            const string Products1Path = $"{FilesPath}products1.json";
            const string Products2Path = $"{FilesPath}products2.json";

            //EX1(Products1Path);
            //EX2(Products1Path);
            //EX3(Products1Path);
            //EX4(Products1Path);
            EX5(Products2Path);
        }

        public static List<Product1> ConvertProduct1ToList(string path)
        {
            string jsonFile;
            using (StreamReader sr = new StreamReader(path))
            {
                jsonFile = sr.ReadToEnd();
            }

            List<Product1> products1 = JsonConvert.DeserializeObject<List<Product1>>(jsonFile);
            return products1;
        }

        public static List<Product2> ConvertProduct2ToList(string path)
        {
            string jsonFile;
            using (StreamReader sr = new StreamReader(path))
            {
                jsonFile = sr.ReadToEnd();
            }

            List<Product2> products2 = JsonConvert.DeserializeObject<List<Product2>>(jsonFile);
            return products2;
        }

        // EX 1
        public static void EX1(string path)
        {
            List<Product1> products = ConvertProduct1ToList(path);

            foreach (Product1 product in products)
            {
                if (product.Price > 600)
                {
                    string json = JsonConvert.SerializeObject(product);
                    Console.WriteLine(json);
                }
            }
        }

        public static void EX2(string path)
        {
            List<Product1> products = ConvertProduct1ToList(path);

            foreach(Product1 product in products)
            {
                if (product.Name == "iPhone 8" && !product.Categories.Contains("supersmartphone"))
                {
                    product.Categories.Add("supersmartphone");
                }
            }

            string updatedJson = JsonConvert.SerializeObject(products);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(updatedJson);
            }

            List<Product1> productsUpdated = ConvertProduct1ToList(path);

            foreach (Product1 product in productsUpdated)
            {
                if (product.Name == "iPhone 8")
                {
                    foreach(string cat in product.Categories)
                    {
                        Console.Write($"CATEGORIA: {cat} | ");
                    }
                }
            }
        }

        public static void EX3(string path)
        {
            List<Product1> products = ConvertProduct1ToList(path);

            foreach (Product1 product in products)
            {
                if (product.Name == "MacBook")
                {
                    product.Stock = 5;
                }
            }

            string updatedJson = JsonConvert.SerializeObject(products);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(updatedJson);
            }
        }

        public static void EX4(string path)
        {
            string jsonFile;
            using (StreamReader sr = new StreamReader(path))
            {
                jsonFile = sr.ReadToEnd();
            }

            List<Product1> products = JsonConvert.DeserializeObject<List<Product1>>(jsonFile);

            for(int i = 0; i < products.Count; i++)
            {
                if (products[i].Stock > 100)
                {
                    products.Remove(products[i]);
                }
            }

            string updatedJson = JsonConvert.SerializeObject(products);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(updatedJson);
            }
        }

        public static void EX5(string path)
        {
            List<Product2> products2 = ConvertProduct2ToList(path);

            foreach (Product2 product2 in products2)
            {
                if (product2.Name == "iPhone 8" && !product2.Categories.Any(c => c.Id == 10 && c.Name == "supersmarthpone"))
                {
                    product2.Categories.Add(new Categories(10,"supersmarthpone"));
                }
            }

            string updatedJson = JsonConvert.SerializeObject(products2, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(updatedJson);
            }

            string updatedJsonContent;
            using (StreamReader sr = new StreamReader(path))
            {
                updatedJsonContent = sr.ReadToEnd();
            }

            List<Product2> products2Updated = JsonConvert.DeserializeObject<List<Product2>>(updatedJsonContent);

            foreach (Product2 product2 in products2Updated)
            {
                if (product2.Name == "iPhone 8")
                {
                    Console.WriteLine("Categories of iPhone 8:");
                    foreach (Categories category in product2.Categories)
                    {
                        Console.WriteLine(category);
                    }
                }
            }
        }
    }
}