using cat.itb.M6UF2EA2.Cruds;

namespace cat.itb.M6UF2EA2
{
    class Program
    {
        public static void Main()
        {
            GeneralCRUD generalCrud = new GeneralCRUD();
            EmpleatCRUD empleatCrud = new EmpleatCRUD();
            ClientCRUD clientCRUD = new ClientCRUD();
            ProducteCRUD producteCrud = new ProducteCRUD();

            List<string> tables = new List<string>();
            tables.Add("client");
            tables.Add("emp");
            tables.Add("producte");
            tables.Add("dept");
            tables.Add("comanda");
            tables.Add("detall");

            //producteCrud.EX1();
            //empleatCrud.EX2();
            //clientCRUD.EX3();
            //clientCRUD.EX4(106);
            //empleatCrud.EX5(7788);
            //producteCrud.EX6(101860);
            //empleatCrud.EX7();
            //clientCRUD.EX8(109);
            //empleatCrud.EX9(4885);
            //producteCrud.EX10(400552);
        }
    }
}