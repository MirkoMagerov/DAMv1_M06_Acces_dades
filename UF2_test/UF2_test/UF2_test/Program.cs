//Npgsql .NET Data Provider for PostgreSQL

using UF2_test;
using UF2_test.cruds;
using UF2_test.model;

class Program
{
    static void Main(string[] args)
    {
        AsignaturasCRUD crud = new AsignaturasCRUD();

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

        /*
        SelectStudentByID();
        Console.WriteLine();
        SelectStudentByName();
        Console.WriteLine();
        SelectAllStudents();
        Console.WriteLine();
        InsertStudent();
        SelectAllStudents();
        Console.WriteLine();
         UpdateStudent();
         SelectAllStudents();
         Console.WriteLine();
         DeleteStudent();
         SelectAllStudents();
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
        
        private static void SelectStudentByName()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students  = scrud.SelectByName("Roc");
         
            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
           
        }
        
        private static void SelectAllStudents()
        {
            StudentCRUD scrud = new StudentCRUD();
            IList<Student> students = scrud.SelectAll();

            foreach (Student student in students)
            {
                Console.WriteLine("ID:{0} " + "Nom:{1} " + "Cognom:{2} ", student.id, student.firstname, student.lastname );
            }
        }
        
        private static void InsertStudent()
        {

            StudentCRUD scrud = new StudentCRUD();
             var student = new Student
                    {
                        firstname = "Quim",
                        lastname = "Guix"
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
}
    
    



