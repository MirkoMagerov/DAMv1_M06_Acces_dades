namespace cat.itb.M6UF2EA2.Model
{
    public class Producte
    {
        public int Prod_num { get; set; }
        public string Descripcio { get; set; }

        public Producte()
        {
            Prod_num = 0;
            Descripcio = null;
        }

        public Producte(int prod_num, string descripcio)
        {
            Prod_num = prod_num;
            Descripcio = descripcio;
        }
    }
}
