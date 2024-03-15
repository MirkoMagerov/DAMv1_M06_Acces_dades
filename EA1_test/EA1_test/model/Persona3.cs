namespace EA1_test;

[Serializable]
public class Persona3
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Cognoms { get; set; }
    public int Edat { get; set;  }
        
    public override string ToString()
    {
        return "Id: " + Id + "  Nom: " + Nom + "   Cognoms: " + Cognoms + "   Edat: " + Edat;
    }
        
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Persona3 objAsPersona3 = obj as Persona3;
        if (objAsPersona3 == null) return false;
        else return Equals(objAsPersona3);
    }
        
    public override int GetHashCode()
    {
        return Id;
    }
    public bool Equals(Persona3 other)
    {
        if (other == null) return false;
        return (this.Id.Equals(other.Id));
    }
        
}