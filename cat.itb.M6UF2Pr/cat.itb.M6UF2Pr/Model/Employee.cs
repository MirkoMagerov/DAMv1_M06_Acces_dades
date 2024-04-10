namespace cat.itb.M6UF2Pr.Model
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Job { get; set; }
        public virtual int Managerno { get; set; }
        public virtual DateTime Startdate { get; set; }
        public virtual double Salary { get; set; }
        public virtual double Commission { get; set; }
        public virtual int Deptno { get; set; }
        public virtual ISet<Product> Products { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Surname: {Surname}, Job: {Job}, ManagerNo: {Managerno}, StartDate: {Startdate}, Salary: {Salary}, Commission: {Commission}, DeptNo: {Deptno}";
        }
    }
}
