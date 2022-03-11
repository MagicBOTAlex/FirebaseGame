using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Http;
using Newtonsoft.Json;

public static class FirebaseHandler 
{
    static FirebaseClient firebase = new FirebaseClient("https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/");

    public static void PersonalMain()
    {
        var jObject = new DatabaseStructure();
        var random = new Random();
        var randomArr = new int[10];
        for (int i = 0; i < randomArr.Length; i++)
        {
            randomArr[i] = random.Next(1000);
        }
        jObject.Scores = randomArr;

        firebase.Child("database").PatchAsync(JsonConvert.SerializeObject(jObject)).Wait();
    }

    public static DatabaseStructure GetData()
    {
        var client = new HttpClient();
        var response = client.GetAsync("https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/database.json");

        return JsonConvert.DeserializeObject<DatabaseStructure>(response.ToString());
    }

    public static void AddScore(int score)
    {
        var data = GetData();
        var dumbList = data.Scores.ToList();
        dumbList.Add(score);
        data.Scores = dumbList.ToArray();

        firebase.Child("database").PatchAsync(JsonConvert.SerializeObject(data)).Wait();
    }
}

public class DatabaseStructure
{
    public int[] Scores { get; set; }
}
