namespace cat.itb.M6UF1EA2
{
    public class Product1
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public List<string> Categories { get; set; }

        public Product1(string name, double price, int stock, string picture, List<string> categories)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Picture = picture;
            Categories = categories;
        }
    }
}
