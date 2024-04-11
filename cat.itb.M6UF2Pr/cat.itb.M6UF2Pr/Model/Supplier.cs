namespace cat.itb.M6UF2Pr.Model
{
    public class Supplier
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string StCode { get; set; }
        public virtual string Zipcode { get; set; }
        public virtual int Area { get; set; }
        public virtual string Phone { get; set; }
        public virtual int Amount { get; set; }
        public virtual double Credit { get; set; }
        public virtual string Remark { get; set; }
        public virtual Product Product { get; set; }
        public virtual ISet<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address}, City: {City}, StateCode: {StCode}, ZipCode: {Zipcode}, Area: {Area}, Phone: {Phone}, ProductNo: {Product.Description}, Amount: {Amount}, Credit: {Credit}, Remark: {Remark}";
        }
    }
}
