//Npgsql .NET Data Provider for PostgreSQL

using UF2_test;
using UF2_test.cruds;
using UF2_test.model;

class Program
{
    static void Main(string[] args)
    {
        AsignaturasCRUD crud = new AsignaturasCRUD();

        GeneralCRUD gcrud = new GeneralCRUD();

        //Mètodes exemples EA1

        // crud.SelectVersion();
        // crud.SelectAllSubjects1();
        //  crud.SelectAllSubjects2();
        //  crud.SelectSubjectPS();
        //  crud.InsertSubject();
        // crud.DeleteSubject(7);
        //  crud.DeleteSubject(8);
        // crud.InsertSubjectPS();
        //  crud.DeleteSubjectPS(6);
        //crud.InsertMoreThanOneSubjectPS();

        //Mètodes exemples EA2

        //SelectAllSubjects();
        // SelectOneSubject(3);

        //Creem un nou Subject al Main
        var subject = new Asignatura
        {
            cod = 20,
            nombre = "FÍSICA"
        };

        //I l'insertem
        // crud.InsertSubjectPS2(subject);

        //Comprovem la nova inserció
        //SelectAllSubjects();

        //Fem una actualitzció utilizant el SELECT, DELETE and INSERT
        //UpdateSubject(20, "BIOLOGIA");

        //Comprovem el canvi
        //SelectAllSubjects();


        //Mètodes exemples EA3

        //Fluent NHibernate
        // SelectStudentByID();
        // Console.WriteLine();
        //  SelectStudentByNameHQL();
        // Console.WriteLine();
        //  SelectAllStudentsHQL();
        // Console.WriteLine();
        // InsertStudent();
        // SelectAllStudentsHQL();
        // Console.WriteLine();
        //  UpdateStudent();
        //  SelectAllStudentsHQL();
        //  Console.WriteLine();
        //  DeleteStudent();
        //  SelectAllStudentsLinq();

        //Mètodes exemples EA4

        //gcrud.RunScriptStudent();

        //Just Querys With NHibernate

        //Query Native SQL
        //SelectAllStudentsNativeSQL();
        // Console.WriteLine();
        //SelectStudentByNameNativeSQL();
        // Console.WriteLine();

        //Query HQL
        // SelectAllStudentsHQL();
        // Console.WriteLine();
        //SelectStudentByNameHQL();
        // Console.WriteLine();
        //SelectByLastNameStartsByHQL();
        //Console.WriteLine();

        //Query Criteria
        // SelectAllStudentsCriteria();
        //Console.WriteLine();
        //SelectStudentByNameCriteria();
        //Console.WriteLine();
        //SelectStudentByLastNameCriteria();
        //Console.WriteLine();
        //SelectByLastNameStartsByCriteria();
        //Console.WriteLine();

        //Query Linq

  /*
        SelectAllStudentsLinq();
        Console.WriteLine();
        SelectStudentByLastNameLinq();
        Console.WriteLine();
        SelectStudentByLastNameLinq2();
        Console.WriteLine();
        SelectByLastNameStartsByLinq();
        Console.WriteLine();
  */  
        //Query QueryOver 
        
        /*
           SelectAllStudentsQueryOver();
           Console.WriteLine();
           SelectStudentsByAgeIntervalQueryOver();
           Console.WriteLine();
           SelectStudentsByAgeGreatToQueryOver();
           Console.WriteLine();
           SelectOldestStudentsQueryOver();
           Console.WriteLine(); 
        */

    }

    private static void SelectAllSubjects()
        {
            AsignaturasCRUD crud = new AsignaturasCRUD();
            List<Asignatura> subjects = crud.SelectAllSubjects3();

            foreach (Asignatura subject in subjects)
            {
                Console.WriteLine("Codi:{0} " + "Nom:{1} ", subject.cod, subject.nombre);
            }
        }

        private static void SelectOneSubject(int codi)
        {
            AsignaturasCRUD crud = new AsignaturasCRUD();
            Asignatura subject = crud.SelectSubjectPS2(codi);
            Console.WriteLine("Codi:{0} " + "Nom:{1} ", subject.cod, subject.nombre);

        }

    public static void UpdateSubject(int pcodi, string pnom)
    {
        AsignaturasCRUD crud = new AsignaturasCRUD();
        var subject = crud.SelectSubjectPS2(pcodi);
        subject.nombre = pnom;
        crud.DeleteSubject(pcodi);
        crud.InsertSubjectPS2(subject);

        Console.WriteLine("row updated");
    }
    private static void SelectStudentByID()
        {

            StudentCRUD scrud = new StudentCRUD();
            var student = scrud.SelectById(2);
            Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
        }
        
        
        private static void InsertStudent()
        {

            StudentCRUD scrud = new StudentCRUD();
             var student = new Student
                    {
                        firstname = "Quim",
                        lastname = "Guix",
                        age = 24
                    };
      
           scrud.Insert(student);         
           
        }
        
        private static void UpdateStudent()
        {
            StudentCRUD scrud = new StudentCRUD();
            
            Console.WriteLine("Student for updating:");
            var student = scrud.SelectById(5);
            Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            student.firstname = "Ramon";
            scrud.Update(student);
        }
        
        private static void DeleteStudent()
        {
            StudentCRUD scrud = new StudentCRUD();
            
            var student = scrud.SelectById(5);
            scrud.Delete(student);
        }
        
        private static void SelectAllStudentsNativeSQL()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectAllNativeSQL();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }
        
        private static void SelectStudentByNameNativeSQL()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByNameNativeSQL("Roc");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }
        
        private static void SelectAllStudentsHQL()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectAllHQL();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }
        
        private static void SelectStudentByNameHQL()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByNameHQL("Roc");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }
        
        private static void SelectByLastNameStartsByHQL()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByLastNameStartsByHQL("V");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }

        private static void SelectAllStudentsCriteria()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectAllCriteria();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }
        
        private static void SelectStudentByNameCriteria()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByNameCriteria("Roc");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }
        
        private static void SelectStudentByLastNameCriteria()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByLastNameCriteria("Peris");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }
        
        private static void SelectByLastNameStartsByCriteria()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByLastNameStartsByCriteria("V");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }

        private static void SelectAllStudentsLinq()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectAllLinq();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }
        
        private static void SelectStudentByLastNameLinq()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByLastNameLinq("Rull");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }

        }
        
        private static void SelectStudentByLastNameLinq2()
        {
            StudentCRUD scrud = new StudentCRUD();
            Student student  = scrud.SelectByLastNameLinq2("Peris");
         
           Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            
        }
        private static void SelectByLastNameStartsByLinq()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByLastNameStartsByLinq("V");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }

        private static void SelectAllStudentsQueryOver()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectAllQueryOver();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }
        
        private static void SelectStudentsByAgeIntervalQueryOver()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectByAgeIntervalQueryOver(22,26);

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} " + "Edat:{3} ", student.id, student.firstname, student.lastname,student.age);
            }
        }
        
        private static void SelectStudentsByAgeGreatToQueryOver()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<String> studentNames = scrud.SelectByAgeGreatToQueryOver(26);

            foreach (String studentName in studentNames)
            {
                Console.WriteLine(studentName);
            }
        }
        
        private static void SelectOldestStudentsQueryOver()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectOldestQueryOver();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} " + "Edat:{3} ", student.id, student.firstname, student.lastname,student.age);
            }
        }
        
}
    
    



