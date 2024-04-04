namespace cat.itb.M6UF2EA3.Model
{
    public class Departamento
    {
        public virtual int Id { get; set; }
        public virtual string Dnombre { get; set; }
        public virtual string Loc { get; set; }
        // public virtual List<Empleado> Empleados { get; set; }

        public Departamento()
        {

        }

        public Departamento(string dnombre, string loc)
        {
            Dnombre = dnombre;
            Loc = loc;
        }

        public override string ToString()
        {
            string result = "";

            result += $"Id: {Id} \n";
            result += $"Dnombre: {Dnombre} \n";
            result += $"Loc: {Loc} \n";
            //result += $"Empleados: ";
            //foreach(Empleado emp in Empleados)
            //{
            //    result += $"{emp.Apellido}, ";
            //}

            return result;
        }
    }
}
