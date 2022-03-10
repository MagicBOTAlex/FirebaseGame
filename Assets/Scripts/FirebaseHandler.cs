using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Http;

public static class FirebaseHandler 
{
    public static void PersonalMain()
    {
        PersonalMainAsync().GetAwaiter().GetResult();
    }

    public static async Task PersonalMainAsync()
    {
        var firebase = new FirebaseClient("https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/");
        var somethings = await firebase.Child("database").PostAsync("{\"testing\":true}");
        return;
    }
}
