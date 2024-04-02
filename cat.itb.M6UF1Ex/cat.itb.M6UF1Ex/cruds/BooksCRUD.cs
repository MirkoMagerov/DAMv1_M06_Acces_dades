using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace cat.itb.M6UF1Ex.cruds
{
    public class BooksCRUD
    {
        public void EX1()
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            string converted = JsonConvert.SerializeObject(books, Formatting.Indented);

            Console.WriteLine(converted);
        }

        public void EX2()
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            Console.WriteLine($"Número de libros antes de la modificación: {books.Count}.");

            Book addBook = new Book();
            addBook._id = 321;
            addBook.title = "SNOOPY Y CARLITOS 1969-1970 Nº 10/25 (NUEVA EDICIÓN)";
            addBook.isbn = "9788491465522";
            addBook.pageCount = 352;
            addBook.thumbnailUrl = "https://www.casadellibro.com/libro-snoopy-y-carlitos-1969af1970-nba-102f25-nueva-edicion/9788491465522/9476893";
            addBook.shortDescription = "Tiras publicadas entre 1969 y 1970 de Carlitos, la obra maestra de Charles M. Schulz. El mundo de Carlitos es un microcosmos, una pequeña comedia humana válida tanto para el lector inocente como para el sofisticado.Y la mejor manera de apreciar lo expuesto es esta edición en la que permite apreciar viñeta a viñeta la evolución tanto del artista como de los personajes.";
            addBook.status = "MEAP";
            addBook.authors = ["Charles M. Schulz"];
            addBook.categories = ["Cómic Adulto"];

            books.Add(addBook);

            string converted = JsonConvert.SerializeObject(books, Formatting.Indented);

            File.WriteAllText(path, converted);

            string newJson;
            using (StreamReader sr = new StreamReader(path))
            {
                newJson = sr.ReadToEnd();
            }

            List<Book> newBooks = JsonConvert.DeserializeObject<List<Book>>(newJson);

            Console.WriteLine($"Número de libros después de la modificación: {newBooks.Count}.");
        }

        public void EX3()
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            foreach(Book book in books)
            {
                Console.WriteLine($"Título: {book.title} | Autores: {book.authors.Count}");
            }
        }

        public void EX4(string cat)
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            List<Book> javaBooks = books.FindAll(b => b.categories.Contains(cat));

            foreach(Book book in javaBooks)
            {
                Console.Write($"Títol: {book.title}, Autors: ");
                foreach (string autor in book.authors)
                {
                    Console.Write(autor + ",");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            
            Console.WriteLine();
            Console.WriteLine();
        }

        public void EX5(string title, string cat)
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            Book modifyBook = books.Find(b => b.title.Contains(title));

            Console.Write($"Categorias del libro {modifyBook.title} antes de la modificación:");
            foreach (string category in modifyBook.categories)
            {
                Console.Write(category + ",");
            }

            Console.WriteLine();
            modifyBook.categories.Add(cat);

            Console.Write($"Categorias del libro {modifyBook.title} después de la modificación:");
            foreach (string category in modifyBook.categories)
            {
                Console.Write(category + ",");
            }
            Console.WriteLine();

            string modified = JsonConvert.SerializeObject(books, Formatting.Indented);

            File.WriteAllText(path, modified);
        }

        public void EX6(string title, string oldAuthor, string newAuthor)
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            Book modifyBook = books.Find(b => b.title.Contains(title));

            Console.WriteLine($"Autores del libro {modifyBook.title} antes de la modificación: ");
            for(int i = 0; i < modifyBook.authors.Count; i++)
            {
                Console.Write(modifyBook.authors[i] + ", ");
                if (modifyBook.authors[i] == oldAuthor) modifyBook.authors[i] = newAuthor;
            }

            Console.WriteLine();

            Console.WriteLine($"Autores del libro {modifyBook.title} después de la modificación: ");
            foreach (string author in modifyBook.authors)
            {
                Console.Write(author + ", ");
            }
            Console.WriteLine();

            string updatedJson = JsonConvert.SerializeObject(books, Formatting.Indented);

            File.WriteAllText(path, updatedJson);
        }

        public void EX7(string ISBN, int posicio, string newAuthor)
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            Book modifyBook = books.Find(b => b.isbn == ISBN);

            foreach (string author in modifyBook.authors)
            {
                Console.Write(author + ", ");
            }
            Console.WriteLine();
            modifyBook.authors[posicio] = newAuthor;

            Console.WriteLine($"Autores del libro {modifyBook.title} después de la modificación: ");
            foreach (string author in modifyBook.authors)
            {
                Console.Write(author + ", ");
            }
            Console.WriteLine();

            string updatedJson = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
        }

        public void EX8(string bookTitle, string newAuthor)
        {
            string path = @"..\..\..\files\books.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            Book modifyBook = books.Find(b => b.title == bookTitle);

            Console.WriteLine($"Autores del libro {modifyBook.title} antes de la modificación: ");
            foreach (string author in modifyBook.authors)
            {
                Console.Write(author + ", ");
            }
            Console.WriteLine();
            modifyBook.authors.Add(newAuthor);

            Console.WriteLine($"Autores del libro {modifyBook.title} después de la modificación: ");
            foreach (string author in modifyBook.authors)
            {
                Console.Write(author + ", ");
            }
            Console.WriteLine();
        }

        public void EX9()
        {
            string path = @"..\..\..\files\books.json";
            string savePath = @"..\..\..\files\bigBooks.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            List<Book> moreThan500Pages = books.FindAll(b => b.pageCount > 500);

            string updatedJson = JsonConvert.SerializeObject(moreThan500Pages, Formatting.Indented);
            File.WriteAllText(savePath, updatedJson);
        }

        public void EX10()
        {
            string path = @"..\..\..\files\bigBooks.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            foreach(Book book in books)
            {
                Console.Write($"Título: {book.title}, Categorías: ");
                foreach(string cat in book.categories)
                {
                    Console.Write(cat + ", ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void EX11()
        {
            string path = @"..\..\..\files\books.json";
            string savePath = @"..\..\..\files\notPublishedBooks.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            List<Book> notPublish = books.FindAll(s => s.status != "PUBLISH");
    
            string updatedJson = JsonConvert.SerializeObject(notPublish, Formatting.Indented);
            File.WriteAllText(savePath, updatedJson);
        }

        public void EX12()
        {
            string path = @"..\..\..\files\notPublishedBooks.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            foreach(Book book in books)
            {
                Console.WriteLine($"Títol: {book.title}, Status: {book.status}, ISBN: {book.isbn}");
            }
        }

        public void EX13()
        {
            string path = @"..\..\..\files\notPublishedBooks.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            JArray jArray = JArray.Parse(json);
            foreach(JObject jObject  in jArray)
            {
                jObject.Add("Assessment", new JValue(3000));
            }

            string modified = JsonConvert.SerializeObject(jArray, Formatting.Indented);
            File.WriteAllText(path, modified);
        }

        public void EX14()
        {
            string path = @"..\..\..\files\notPublishedBooks.json";
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                jObject.Remove("thumbnailUrl");
            }

            string modified = JsonConvert.SerializeObject(jArray, Formatting.Indented);
            Console.WriteLine(modified);
            File.WriteAllText(path, modified);
        }

        public void EX15()
        {
            // Viendo que en books el campo de date empiza con $, podemos poner en la clase de PublishedDate, encima de la propiedad date, podemos poner '[JsonProperty("$date")]' y de esta manera cogerá correctamente el campo date.
        }
    }
}
