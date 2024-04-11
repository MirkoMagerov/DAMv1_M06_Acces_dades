namespace cat.itb.M6UF2Pr.Model
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Description { get; set; }
        public virtual  int Currentstock { get; set; }
        public virtual int Minstock { get; set; }
        public virtual double Price { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Code: {Code}, Description: {Description}, CurrentStock: {Currentstock}, MinStock: {Minstock}, Price: {Price}, EmployeeNo: {Employee.Id}";
        }
    }
}
