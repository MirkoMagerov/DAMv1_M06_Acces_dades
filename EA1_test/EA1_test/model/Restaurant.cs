namespace EA1_test;

[Serializable]
public class Restaurant
{
    //ATTRIBUTES
    public Address address { get; set; }
    public string borough { get; set; }
    public string cuisine { get; set; }
    public List<Grade> grades { get; set; } 
    public string name { get; set; }
    public string restaurant_id { get; set; }


//ToSTRING
public override string ToString()
{
    return "  Address: " + address + "  Borough: " + borough + "   Cuisine: " + cuisine + "   Name: " + name + "   Grades: " + grades + "   Id: " + restaurant_id;
}

}