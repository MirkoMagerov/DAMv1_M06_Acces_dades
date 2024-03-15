using cat.itb.M6UF1EA3.Model;
using Newtonsoft.Json;
using System;

namespace cat.itb.M6UF1EA3.Cruds
{
    public class PeopleCRUDS
    {
        // string path = @"..\..\..\Files\people.json";

        public void EX1()
        {
            string path = @"..\..\..\Files\people.json";

            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(json);

            string personString = JsonConvert.SerializeObject(personList, Formatting.Indented);

            Console.WriteLine(personString);
        }

        public void EX2()
        {
            string path = @"..\..\..\Files\people.json";

            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(json);

            Person JuliaYoung = personList.Find(p => p.Name == "Julia Young");

            JuliaYoung.Friends.Add(new Friend(4, "Trinity Ford"));

            string updatedJson = JsonConvert.SerializeObject(personList, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
        }

        public void EX3()
        {
            string path = @"..\..\..\Files\people.json";

            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(json);

            List<Person> moreThan25 = personList.FindAll(p => p.Age > 25);
            string jsonMoreThan25 = JsonConvert.SerializeObject(moreThan25, Formatting.Indented);

            string outputDirectory = @"..\..\..\Files";
            string outputFileName = "adultPeopleArray.json";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            File.WriteAllText(outputPath, jsonMoreThan25);
        }

        public void EX4()
        {
            string path = @"..\..\..\Files\people.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Person> personList = JsonConvert.DeserializeObject<List<Person>>(json);
            List<Person> teachers = personList.FindAll(t => t.RandomArrayItem == "teacher");
            string teachersJson = JsonConvert.SerializeObject(teachers, Formatting.Indented);

            string outputPath = @"..\..\..\Files\";
            string fileName = "teachers.json";
            string finalPath = Path.Combine(outputPath, fileName);

            File.WriteAllText(finalPath, teachersJson);
        }

        public void EX5()
        {
            string teachersPath = @"..\..\..\Files\teachers.json";
            string json;
            using (StreamReader sr = new StreamReader(teachersPath))
            {
                json = sr.ReadToEnd();
            }

            List<Person> teachers = JsonConvert.DeserializeObject<List<Person>>(json);
            Console.WriteLine("TEACHERS");
            foreach (Person teacher in teachers)
            {
                Console.WriteLine($"Nombre: {teacher.Name}, Edat: {teacher.Age}, Genero: {teacher.Gender}");
            }
        }

        public void EX6()
        {
            string teachersPath = @"..\..\..\Files\teachers.json";
            string json;
            using (StreamReader sr = new StreamReader(teachersPath))
            {
                json = sr.ReadToEnd();
            }

            List<Person> teachers = JsonConvert.DeserializeObject<List<Person>>(json);
            List<Person> maleTeachers = teachers.FindAll(t => t.Gender == "male");

            string maleTeachersString = JsonConvert.SerializeObject(maleTeachers, Formatting.Indented);

            string newPath = @"..\..\..\Files";
            string fileName = "professors.json";
            string output = Path.Combine(newPath, fileName);

            File.WriteAllText(output, maleTeachersString);
        }

        public void EX7()
        {
            string path = @"..\..\..\Files\professors.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Person> professors = JsonConvert.DeserializeObject<List<Person>>(json);

            foreach(Person professor in professors)
            {
                foreach(Friend friend in professor.Friends)
                {
                    Console.WriteLine($"Profesor: {professor.Name}, Amigo: {friend.Name}");
                }
            }
            Console.WriteLine($"En total hay {professors.Count} profesores.");
        }

        public void EX8()
        {
            string professorsPath = @"..\..\..\Files\professors.json";
            string json;
            using (StreamReader sr = new StreamReader(professorsPath))
            {
                json = sr.ReadToEnd();
            }

            List<Person> professors = JsonConvert.DeserializeObject<List<Person>>(json);
            Person Allison = professors.Find(t => t.Name == "Allison Oldman");

            Allison.Tags.Add("sisto");
            Allison.Age = 29;

            string jsonUpdated = JsonConvert.SerializeObject(professors, Formatting.Indented);

            File.WriteAllText(professorsPath, jsonUpdated);
        }
    }
}
