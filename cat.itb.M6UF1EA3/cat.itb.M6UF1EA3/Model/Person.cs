namespace cat.itb.M6UF1EA3.Model
{
    public class Person
    {
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Registered { get; set; }
        public double Latitude { get; set; }
        public List<string> Tags { get; set; }
        public List<Friend> Friends { get; set; }
        public string Gender { get; set; }
        public string RandomArrayItem { get; set; }

        public Person(bool isActive, string balance, string picture, int age, string name, string company, string phone, string email, string address, string about, string registered, double latitude, List<string> tags, List<Friend> friends)
        {
            IsActive = isActive;
            Balance = balance;
            Picture = picture;
            Age = age;
            Name = name;
            Company = company;
            Phone = phone;
            Email = email;
            Address = address;
            About = about;
            Registered = registered;
            Latitude = latitude;
            Tags = tags;
            Friends = friends;
        }
    }
}
