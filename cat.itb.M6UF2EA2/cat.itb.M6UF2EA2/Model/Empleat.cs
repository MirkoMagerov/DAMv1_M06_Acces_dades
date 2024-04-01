namespace cat.itb.M6UF2EA2.Model
{
    public class Empleat
    {
        public int Emp_no { get; set; }
        public string Cognom { get; set; }
        public string Ofici { get; set; }
        public int Cap { get; set; }
        public DateTime Data_alta { get; set; }
        public double Salari { get; set; }
        public double Comissio { get; set; }
        public int Dept_no { get; set; }

        public Empleat()
        {
            Emp_no = 0;
            Cognom = null;
            Ofici = null;
            Cap = 0;
            Data_alta = new DateTime();
            Salari = 0.0;
            Comissio = 0.0;
            Dept_no = 0;
        }

        public Empleat(int emp_no, string cognom, string ofici, int cap, DateTime data_alta, double salari, double comissio, int dept_no)
        {
            Emp_no = emp_no;
            Cognom = cognom;
            Ofici = ofici;
            Cap = cap;
            Data_alta = data_alta;
            Salari = salari;
            Comissio = comissio;
            Dept_no = dept_no;
        }
    }
}
