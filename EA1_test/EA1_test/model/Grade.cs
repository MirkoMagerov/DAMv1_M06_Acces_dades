namespace EA1_test;

public class Grade
{
    //ATTRIBUTES
    public string date { get; set; }
    public char mark { get; set; }
    public int score { get; set; }
    
    //ToSTRING
    public override string ToString()
    {
        return "Date: " + date + "  Mark: " + mark + "   Score: " + score;
    }
    
}