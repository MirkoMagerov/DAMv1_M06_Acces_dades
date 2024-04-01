namespace cat.itb.M6UF2EA2.Model
{
    public class Client
    {
        public int Client_cod { get; set; }
        public string Nom { get; set; }
        public string Adreca { get; set; }
        public string Ciutat { get; set; }
        public string Estat { get; set; }
        public string Codi_postal { get; set; }
        public int Area { get; set; }
        public string Telefon { get; set; }
        public int Repr_cod { get; set; }
        public double Limit_credit { get; set; }
        public string Observacions { get; set; }

        public Client()
        {
            Client_cod = 0;
            Nom = null;
            Adreca = null;
            Ciutat = null;
            Estat = null;
            Codi_postal = null;
            Area = 0;
            Telefon = null;
            Repr_cod = 0;
            Limit_credit = 0.0;
            Observacions = null;
        }

        public Client(int client_cod, string nom, string adreca, string ciutat, string estat, string codi_postal, int area, string telefon, int repr_cod, double limit_credit, string observacions)
        {
            Client_cod = client_cod;
            Nom = nom;
            Adreca = adreca;
            Ciutat = ciutat;
            Estat = estat;
            Codi_postal = codi_postal;
            Area = area;
            Telefon = telefon;
            Repr_cod = repr_cod;
            Limit_credit = limit_credit;
            Observacions = observacions;
        }
    }
}
