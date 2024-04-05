namespace cat.itb.M6UF2EA3.Model
{
    public class Empleado
    {
        public virtual int Id { get; set; }
        public virtual int Empno { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Oficio { get; set; }
        public virtual int Dir { get; set; }
        public virtual DateTime Fechaalt { get; set; }
        public virtual double Salario { get; set; }
        public virtual double Comision { get; set; }
        public virtual Departamento Departamento { get; set; }

        public override string ToString()
        {
            string result = "";
            result += $"------ EMPLEADO ------\n";
            result += $"Id: {Id}\n";
            result += $"Empno: {Empno}\n";
            result += $"Apellido: {Apellido}\n";
            result += $"Oficio: {Oficio}\n";
            result += $"Dir: {Dir}\n";
            result += $"Fechaalt: {Fechaalt}\n";
            result += $"Salario: {Salario}\n";
            result += $"Comision: {Comision}\n";
            result += $"Departamento: {Departamento.Dnombre}, {Departamento.Loc}";

            return result;
        }
    }
}
