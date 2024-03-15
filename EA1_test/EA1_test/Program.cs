using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using EA1_test.cruds;

namespace EA1_test;

class Program
{
    static void Main(string[] args)
    {
        TestCRUD crud = new TestCRUD();
        /*
        crud.Exemple1();
        crud.Exemple2();
        crud.LlegirPersona1();
        crud.EscriurePersona1();
        crud.LlegirPersona2();
        crud.EscriurePersona2();
        crud.LlegirPersona1b();
        crud.LlegirPersones();
        crud.EscriurePersones();
        crud.UpdatePersona3();
        crud.DeletePersona3();
        crud.SelectPersona3();
       */
     //  crud.LlegirRestaurants();
      //  crud.CalculateTotalScore();
      //  crud.ReadRestaurantsArray();
     // crud.ReadRestaurantsArray2();
    // crud.WriteRestaurantsArray();
    // crud.LlegirPersona2Ident();
    //crud.DeletePersona3Remove();
   crud.DeletePersona3RemoveId();
    //crud.DeletePersona1Remove();
   //crud.UpdatePersona3Find();
 
    }
}

    
