using cat.itb.M6UF2Pr.Cruds;

namespace cat.itb.M6UF2Pr
{
    public class Program
    {
        public static void Main()
        {
            List<string> tables = ["employee", "product", "supplier", "orderp"];

            GeneralCRUD genCrud = new GeneralCRUD();
            EmployeeCRUD empCrud = new EmployeeCRUD();

            empCrud.SelectById(3);
        }
    }
}