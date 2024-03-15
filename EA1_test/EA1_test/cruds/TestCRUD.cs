using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EA1_test.cruds;

public class TestCRUD
{
    
    public  void Exemple1()
    {
        var product = new Product
        {
            Name = "Apple",
            ExpiryDate = new DateTime(2008, 12, 28),
            Price = 3.99M,
            Sizes = new[] {"Small", "Medium", "Large"}
        };
       
        string json = JsonConvert.SerializeObject(product);
        Console.WriteLine(json);
        string path = @"../../../FitxersJSON/product3.json";
        System.IO.File.WriteAllText(path, json);
    }

    public  void Exemple2()
    {
        string path2 = @"../../../FitxersJSON/product3.json";
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
    
    public  void LlegirPersona1()
    {
        string path3 = @"../../../FitxersJSON/persona1.json";
        using (StreamReader jsonStream = File.OpenText(path3))
        {
            string person = jsonStream.ReadToEnd();
            Persona1 person1 = JsonConvert.DeserializeObject<Persona1>(person);
            
            string json = JsonConvert.SerializeObject(person1);
            Console.WriteLine(json);
            
        }
    }
    
    public  void LlegirPersona1b()
    {
        string path = @"../../../FitxersJSON/persona1.json";
        StreamReader reader = File.OpenText(path);
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        // string nom = jsonObject ["Nom"].ToString(); 
        //  Console.WriteLine(nom);
        string person = jsonObject.ToString(); 
        Console.WriteLine(person);
        reader.Close();
    }
    
    public  void EscriurePersona1()
    {
        var person = new Persona1
        {
            Nom = "Ramon",
            Cognoms = "Espadaler Roig",
            Edat = 33
        };         

        string json = JsonConvert.SerializeObject(person);
        string path = @"../../../FitxersJSON/persona11.json";
        System.IO.File.WriteAllText(path, json);
        
    }
    
    public  void LlegirPersones()
    {
        string path3 = @"../../../FitxersJSON/persones.json";
        var options = new JsonSerializerOptions { WriteIndented = true };
       
        using (StreamReader jsonStream = File.OpenText(path3))
        {
            string line;
            while((line = jsonStream.ReadLine()) != null)
            {
                Persona1 person1 = JsonConvert.DeserializeObject<Persona1>(line);
               // string json = JsonConvert.SerializeObject(person1);
               // Console.WriteLine(json);
                
                string jsonString = System.Text.Json.JsonSerializer.Serialize(person1, options);
                Console.WriteLine(jsonString);
            }
        }
    }
    
    public  void EscriurePersones()
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
        string path = @"../../../FitxersJSON/persones2.json";

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json1);
            sw.WriteLine(json2);
        }
    }
    
    public  void LlegirPersona2()
    {
        string path = @"../../../FitxersJSON/persona2.json";
        StreamReader jsonStream = File.OpenText(path);
        string person = jsonStream.ReadToEnd();
        Persona2 person2 = JsonConvert.DeserializeObject<Persona2>(person);
        string json = JsonConvert.SerializeObject(person2);
        Console.WriteLine(json);
    }
    
    public  void EscriurePersona2()
    {
       
        var person = new Persona2
        {
            Nom = "Pep",
            Cognoms = "Molist Grau",
            Edat = 45,
            Assignatures = new Assignatura[] { new Assignatura {Id = 5, Nom = "Java"}, new Assignatura {Id = 7, Nom = "Bases de Dades"} }
        };         

        string json = JsonConvert.SerializeObject(person);
        string path = @"../../../FitxersJSON/persona22.json";
        System.IO.File.WriteAllText(path, json);
    }
    
    public void UpdatePersona3()
    {
        List<Persona3> people1 = new List<Persona3>();
        List<Persona3> people2 = new List<Persona3>();
        string path = @"../../../FitxersJSON/persones3.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                //string json = JsonConvert.SerializeObject(person3);
                //Console.WriteLine(json);
                // Console.WriteLine(person);
                people1.Add(person);
            }
        }

        Console.WriteLine("JSON file original");
        foreach (Persona3 person in people1)
        {
            Console.WriteLine(person);
        }

        foreach (Persona3 person in people1)
        {
            if (person.Nom == "Josep")
            {
                person.Edat = 56;
            }

            people2.Add(person);
        }

        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Persona3 person in people2)
            {
                string json = JsonConvert.SerializeObject(person);
                sw.WriteLine(json);
            }
        }

        Console.WriteLine("JSON file changed");
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                Console.WriteLine(person);
            }
        }
    }
    
    public void DeletePersona3()
    {
        List<Persona3> people1 = new List<Persona3>();
        List<Persona3> people2 = new List<Persona3>();
        string path = @"../../../FitxersJSON/persones3.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                people1.Add(person);
            }
        }

        Console.WriteLine("JSON file original");
        foreach (Persona3 person in people1)
        {
            Console.WriteLine(person);
        }

        foreach (Persona3 person in people1)
        {
            if (person.Nom != "Josep")
            {
                people2.Add(person);
            }
        }

        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Persona3 person in people2)
            {
                string json = JsonConvert.SerializeObject(person);
                sw.WriteLine(json);
            }
        }

        Console.WriteLine("JSON file changed");
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                Console.WriteLine(person);
            }
        }
    }
    public void SelectPersona3()
    {
        List<Persona3> people1 = new List<Persona3>();
        List<Persona3> people2 = new List<Persona3>();
        string path = @"../../../FitxersJSON/persones3.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                people1.Add(person);
            }
        }

        foreach (Persona3 person in people1)
        {
            if (person.Edat > 35)
            {
                Console.WriteLine(person);
                people2.Add(person);
            }
        
        }
        string path2 = @"../../../FitxersJSON/persones3Select.json";
        using (StreamWriter sw = new StreamWriter(path2))
        {
            foreach (Persona3 person in people2)
            {
                string json = JsonConvert.SerializeObject(person);
                sw.WriteLine(json);
            }
        }

        Console.WriteLine("JSON file select");
        using (StreamReader jsonStream = File.OpenText(path2))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                Console.WriteLine(person);
            }
        }
    }

   public void LlegirRestaurants()
    {
        string path = @"../../../FitxersJSON/restaurants.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while((line = jsonStream.ReadLine()) != null)
            {
                Restaurant rest = JsonConvert.DeserializeObject<Restaurant>(line);
               // string json = JsonConvert.SerializeObject(rest);
               //Console.WriteLine(json);
                Console.WriteLine("Id:" + rest.restaurant_id + " Zipcode:" + rest.address.zipcode);
            }
        } 
    }

    public void CalculateTotalScore()
    {
        string path = @"../../../FitxersJSON/restaurants.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while((line = jsonStream.ReadLine()) != null)
            {
                Restaurant rest = JsonConvert.DeserializeObject<Restaurant>(line);
                if (rest.restaurant_id == "30191841")
               {
                   //TOTAL SCORE CALCULATION
                   int totalScore = 0;
                   
                   foreach (Grade g in rest.grades)
                   {
                       totalScore = totalScore + g.score;
                   }
                   
                //OUTPUT
                Console.WriteLine("Number of grades: " + rest.grades.Count);
                Console.WriteLine("Total Score: " + totalScore);
                  
               }
            }
        }
    }
    public void ReadRestaurantsArray()
    {
        string path = @"../../../FitxersJSON/restaurantsArray.json";
        StreamReader jsonStream = File.OpenText(path);
        string fileString = jsonStream.ReadToEnd();
        Restaurant[] rests = JsonConvert.DeserializeObject<Restaurant[]>(fileString);
        foreach (Restaurant rest in rests)
        {
            Console.WriteLine("Id:" + rest.restaurant_id + " Zipcode:" + rest.address.zipcode);
        }
    }
    
    public void ReadRestaurantsArray2()
    {
        string path = @"../../../FitxersJSON/restaurantsArray.json";
        StreamReader jsonStream = File.OpenText(path);
        string fileString = jsonStream.ReadToEnd();
        List<Restaurant> rests = JsonConvert.DeserializeObject<List<Restaurant>>(fileString);
        foreach (Restaurant rest in rests)
        {
            Console.WriteLine("Id:" + rest.restaurant_id + " Zipcode:" + rest.address.zipcode);
        }
    }
    

    public void WriteRestaurantsArray()
    {
        string path = @"../../../FitxersJSON/restaurantsArray.json";
        StreamReader jsonStream = File.OpenText(path);
        string fileString = jsonStream.ReadToEnd();
        Restaurant[] rests = JsonConvert.DeserializeObject<Restaurant[]>(fileString);
        string path2 = @"../../../FitxersJSON/restaurantsArray2.json";
        string fileString2 = JsonConvert.SerializeObject(rests);
        File.WriteAllText(path2, fileString2);
        }
    
    public void LlegirPersona2Ident()
    {
        string path = @"../../../FitxersJSON/persona2.json";
        StreamReader jsonStream = File.OpenText(path);
        string person = jsonStream.ReadToEnd();
        Persona2 person2 = JsonConvert.DeserializeObject<Persona2>(person);
        
        string json1 = JsonConvert.SerializeObject(person2);
        Console.WriteLine(json1);
        
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json2 = System.Text.Json.JsonSerializer.Serialize(person2, options);
        Console.WriteLine(json2);
    }
    
    public void DeletePersona3Remove()
    {
        List<Persona3> people = new List<Persona3>();
        string path = @"../../../FitxersJSON/persones3.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                people.Add(person);
            }
        }
        Console.WriteLine("Persones a l'inici");
        foreach (Persona3 person in people.ToList())
        {
            Console.WriteLine(person);
            if (person.Nom == "Josep")
            {
                people.Remove(person);
            }
           }
        
        Console.WriteLine("Persones al final");
        foreach (Persona3 person in people)
        {
            Console.WriteLine(person);
        }
    }
    
    public void DeletePersona3RemoveId()
    {
        List<Persona3> people = new List<Persona3>();
        string path = @"../../../FitxersJSON/persones3.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                people.Add(person);
            }
        }
        Console.WriteLine("Persones a l'inici");
        foreach (Persona3 person in people.ToList())
        {
            Console.WriteLine(person);
          
        }
       // people.RemoveAt(4);
        people.RemoveRange(1,3);
        Console.WriteLine("Persones al final");
        foreach (Persona3 person in people)
        {
            Console.WriteLine(person);
        }
    }
    
    public void DeletePersona1Remove()
    {
        List<Persona1> people = new List<Persona1>();
        string path = @"../../../FitxersJSON/persones.json";
        using (StreamReader jsonStream = File.OpenText(path))
        {
            string line;
            while ((line = jsonStream.ReadLine()) != null)
            {
                Persona1 person = JsonConvert.DeserializeObject<Persona1>(line);
                people.Add(person);
            }
        }
        Console.WriteLine("Persones a l'inici");
        foreach (Persona1 person in people.ToList())
        {
            Console.WriteLine(person.Cognoms);
            if (person.Nom == "Ramon")
            {
                people.Remove(person);
            }
        }
        
        Console.WriteLine("Persones al final");
        foreach (Persona1 person in people)
        {
            Console.WriteLine(person.Cognoms);
        }
    }
    public void UpdatePersona3Find()
    {
        List<Persona3> people = new List<Persona3>();
        string path = @"../../../FitxersJSON/persones3.json";
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Persona3 person = JsonConvert.DeserializeObject<Persona3>(line);
                people.Add(person);
            }
        }

        Console.WriteLine("JSON file original");
        foreach (Persona3 person in people)
        {
            Console.WriteLine(person);
        }

        Persona3 person2 = people.Find(x => x.Nom.Contains("Josep"));
        people.Remove(person2);
        person2.Edat = 56;
        people.Insert(2,person2);
        
        string path2 = @"../../../FitxersJSON/persones3Array.json";
        string fileString1 = JsonConvert.SerializeObject(people);
        File.WriteAllText(path2,fileString1);
        
        Console.WriteLine("JSON file changed");
        StreamReader jsonStream = File.OpenText(path2);
        string fileString2 = jsonStream.ReadToEnd();
        List<Persona3> people2 = JsonConvert.DeserializeObject<List<Persona3>>(fileString2);
        foreach (Persona3 person in people2)
        {
            Console.WriteLine(person);
        }
    }
    
}