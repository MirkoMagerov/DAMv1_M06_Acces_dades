using cat.itb.M6UF2EA3.Cruds;

namespace cat.itb.M6UF2EA3
{
    class Program
    {
        public static void Main()
        {
            DepartamentosCRUD depCrud = new DepartamentosCRUD();
            EmpleadosCRUD empCrud = new EmpleadosCRUD();

            Console.WriteLine(empCrud.SelectById(1).ToString());
        }
    }
}
