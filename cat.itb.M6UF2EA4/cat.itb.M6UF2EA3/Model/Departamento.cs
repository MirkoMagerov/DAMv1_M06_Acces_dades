namespace cat.itb.M6UF2EA3.Model
{
    public class Departamento
    {
        public virtual int Id { get; set; }
        public virtual string Dnombre { get; set; }
        public virtual string Loc { get; set; }
        public virtual IList<Empleado> Empleados { get; set; }

        public override string ToString()
        {
            string result = "";
            result += $"------ DEPARTAMENTO ------\n";
            result += $"Id: {Id} \n";
            result += $"Dnombre: {Dnombre} \n";
            result += $"Loc: {Loc} \n";
            result += $"Empleados: ";
            foreach (Empleado emp in Empleados)
            {
                result += $"{emp.Apellido}, ";
            }

            return result;
        }
    }
}
