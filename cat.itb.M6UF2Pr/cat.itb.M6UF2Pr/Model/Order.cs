namespace cat.itb.M6UF2Pr.Model
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime Orderdate { get; set; }
        public virtual int Amount { get; set; }
        public virtual DateTime Deliverydate { get; set; }
        public virtual double Cost { get; set; }
        public virtual Supplier Supplier { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, SupplierNo: {Supplier.Id}, OrderDate: {Orderdate}, Amount: {Amount}, DeliveryDate: {Deliverydate}, Cost: {Cost}";
        }
    }
}
