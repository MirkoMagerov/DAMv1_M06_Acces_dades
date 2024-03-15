namespace EA1_test;

[Serializable]
public class Address
{
    //ATTRIBUTES
    public int building { get; set; }
    public double[] coord { get; set; }
    public string street { get; set; }
    public int zipcode { get; set; }


//ToSTRING
public override string ToString()
{
    return "Building: " + building + "  Coord: " + coord + "   Street: " + street + "   Zipcode: " + zipcode;
}

}