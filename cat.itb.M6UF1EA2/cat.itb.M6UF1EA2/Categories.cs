namespace cat.itb.M6UF1EA2
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"CATEGORY (ID: {Id} | Name: {Name})";
        }
    }
}
