using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Http;

public static class FirebaseHandler 
{
    static FirebaseClient firebase = new FirebaseClient("https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/");

    public static void PersonalMain()
    {
        firebase.Child("database").PatchAsync("{\"testing\":true}").Wait();
    }
}
