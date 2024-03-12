
using EA1_test;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Exemple1();
        // Exemple2();
        // LlegirPersona1();
        // EscriurePersona1();
        // LlegirPersona2();
        // EscriurePersona2();
        // LlegirPersona1b();
        // LlegirPersones();
        // EscriurePersones();
    }
    
    public static void Exemple1()
    {
        var product = new Product
        {
            Name = "Apple",
            ExpiryDate = new DateTime(2008, 12, 28),
            Price = 3.99M,
            Sizes = new[] {"Small", "Medium", "Large"}
        };         

        string json = JsonConvert.SerializeObject(product);
            
        string path = @"D:\MiroslavMagerov\DAMv1_M06_Acces_dades\Pruebas\product3.json";
        System.IO.File.WriteAllText(path, json);
    }

    public static void Exemple2()
    {
        string path2 = @"D:\MiroslavMagerov\DAMv1_M06_Acces_dades\Pruebas\product3.json";
        using (StreamReader jsonStream = File.OpenText(path2))
        {
            string json2 = jsonStream.ReadToEnd();
            Product product2 = JsonConvert.DeserializeObject<Product>(json2);
            Console.WriteLine(product2.Name);
          
          string[] sizes =  product2.Sizes;
          
         foreach (string i in sizes)
          {
              Console.WriteLine("{0} ", i);
          }
            
           string json3 = JsonConvert.SerializeObject(product2);
            Console.WriteLine(json3);
        }
    }
    
    public static void LlegirPersona1()
    {
        string path3 = @"C:\Joan\FitxersJSON\persona1.json";
        using (StreamReader jsonStream = File.OpenText(path3))
        {
            string person = jsonStream.ReadToEnd();
            Persona1 person1 = JsonConvert.DeserializeObject<Persona1>(person);
            
            string json = JsonConvert.SerializeObject(person1);
            Console.WriteLine(json);
            
        }
    }
    
    public static void LlegirPersona1b()
    {
        string path = @"C:\Joan\FitxersJSON\persona1.json";
        StreamReader reader = File.OpenText(path);
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        // string nom = jsonObject ["Nom"].ToString(); 
        //  Console.WriteLine(nom);
        string person = jsonObject.ToString(); 
        Console.WriteLine(person);
        reader.Close();
    }
    
    public static void EscriurePersona1()
    {
        var person = new Persona1
        {
            Nom = "Ramon",
            Cognoms = "Espadaler Roig",
            Edat = 33
        };         

        string json = JsonConvert.SerializeObject(person);
        string path = @"C:\Joan\FitxersJSON\persona11.json";
        System.IO.File.WriteAllText(path, json);
        
    }
    
    public static void LlegirPersones()
    {
        string path3 = @"C:\Joan\FitxersJSON\persones.json";
        using (StreamReader jsonStream = File.OpenText(path3))
        {
            string line;
            while((line = jsonStream.ReadLine()) != null)
            {
                Persona1 person1 = JsonConvert.DeserializeObject<Persona1>(line);
                string json = JsonConvert.SerializeObject(person1);
                Console.WriteLine(json);
            }
        }
    }
    
    public static void EscriurePersones()
    {
        var person1 = new Persona1
        {
            Nom = "Pepe",
            Cognoms = "Garcia Muñoz",
            Edat = 25
        };    
        
        var person2 = new Persona1
        {
            Nom = "Cisco",
            Cognoms = "Gorg Llopis",
            Edat = 33
        };

        string json1 = JsonConvert.SerializeObject(person1);
        string json2 = JsonConvert.SerializeObject(person2);
        string path = @"C:\Joan\FitxersJSON\persones2.json";

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json1);
            sw.WriteLine(json2);
        }
    }
    
    public static void LlegirPersona2()
    {
        string path = @"C:\Joan\FitxersJSON\persona2.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string person = jsonStream.ReadToEnd();
            Persona2 person2 = JsonConvert.DeserializeObject<Persona2>(person);
            
            string json = JsonConvert.SerializeObject(person2);
            Console.WriteLine(json);
            
        }
    }
    
    public static void EscriurePersona2()
    {
       
        var person = new Persona2
        {
            Nom = "Pep",
            Cognoms = "Molist Grau",
            Edat = 45,
            Assignatures = new Assignatura[] { new Assignatura {Id = 5, Nom = "Java"}, new Assignatura {Id = 7, Nom = "Bases de Dades"} }
        };         

        string json = JsonConvert.SerializeObject(person);
        string path = @"C:\Joan\FitxersJSON\persona22.json";
        System.IO.File.WriteAllText(path, json);
    }
}
