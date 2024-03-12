namespace cat.itb.M6UF1EA1
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public string[] Categories { get; set; }

        public Product(string name, double price, int stock, string picture, string[] categories)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Picture = picture;
            Categories = categories;
        }
    }
}
