using cat.itb.M6UF2EA3.Cruds;
using cat.itb.M6UF2EA3.Model;

namespace cat.itb.M6UF2EA3
{
    class Program
    {
        public static void Main()
        {
            DepartamentosCRUD depCrud = new DepartamentosCRUD();
            EmpleadosCRUD empCrud = new EmpleadosCRUD();

            EX1(depCrud);
            //empCrud.EX2(); ------ NO VA ----------
            //depCrud.EX3();
            
        }

        public static void EX1(DepartamentosCRUD depCrud)
        {
            Departamento dep1 = new Departamento("TECNOLOGIA", "BARCELONA");
            Departamento dep2 = new Departamento("INFORMATICA", "SEVILLA");
            depCrud.Insert(dep1);
            depCrud.Insert(dep2);
        }

        public static void EX2()
        {
            
        }

        public static void EX3(DepartamentosCRUD depCrud)
        {
            Departamento departamento = depCrud.SelectById(2);
            departamento.Dnombre = "RECERCA";
            depCrud.Update(departamento);
        }
    }
}
