using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class FirebaseHandler 
{
    //static FirebaseClient firebase = new FirebaseClient("https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/");

    public static void PersonalMain()
    {
        //var random = new Random();
        //var listToSend = new List<PlayerScore>();
        //for (int i = 0; i < 20; i++)
        //{
        //    listToSend.Add(new PlayerScore() { Score = random.Next(1000), Name = $"Player {random.Next(1000).ToString("0000")}" });
        //}
        //var objectToSend = new DatabaseStructure() { Scores = listToSend.ToArray() };
        //string json = JsonConvert.SerializeObject(objectToSend);

        //SendData(json);
    }

    public static DatabaseStructure GetData()
    {
        var client = new HttpClient();
        var response = client.GetAsync("https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/database.json");

        string responseStr = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        UnityEngine.Debug.Log(responseStr);

        return JsonConvert.DeserializeObject<DatabaseStructure>(responseStr);
    }

    public static void AddScore(string name, float score)
    {
        var data = GetData();
        var dumbList = data.Scores.ToList();
        dumbList.Add(new PlayerScore() { Name = name, Score = score, TimeSubmitted = DateTimeOffset.Now.ToUnixTimeSeconds()});
        data.Scores = dumbList.ToArray();

        string json = JsonConvert.SerializeObject(data);
        SendData(json);

        //firebase.Child("database").PatchAsync(JsonConvert.SerializeObject(data)).Wait();
    }

    public static void SendData(string json)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"https://fir-unity-9-3-2022-default-rtdb.europe-west1.firebasedatabase.app/database.json");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "PATCH";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        //request.Headers.Add("Content-Type", "application/json");
        //request.Headers.Add("User-Agent", "Unity/2022.1.0b11.2843 or something. idk");
        //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //request.Headers.Add("Connection", "keep-alive");

        var response = httpResponse.StatusCode;

        switch ((int)response)
        {
            case 200:
                UnityEngine.Debug.Log("Data successfully sent!");
                break;

            case 404:
                UnityEngine.Debug.Log("Code still fucked or you got no internet. Idk");
                break;

            case 400:
                UnityEngine.Debug.Log("Permission denied. You hacker?");
                break;

            default:
                UnityEngine.Debug.Log($"Zhentao's code is clapped and needs to be fixed. Error code: {(int)response}");
                break;
        }
    }
}

public class DatabaseStructure
{
    public PlayerScore[] Scores { get; set; }
}

public class PlayerScore
{
    public string Name { get; set; }
    public float Score { get; set; }
    public long TimeSubmitted { get; set; }
}
