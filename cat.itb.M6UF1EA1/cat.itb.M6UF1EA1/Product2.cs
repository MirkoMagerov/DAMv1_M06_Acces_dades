﻿namespace cat.itb.M6UF1EA1
{
    public class Product2
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public List<Categories> Categories { get; set; }

        public Product2(string name, double price, int stock, string picture, List<Categories> categories)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Picture = picture;
            Categories = categories;
        }
    }
}
