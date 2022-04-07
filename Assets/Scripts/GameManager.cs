using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Refrences")]
    public GameObject Player;
    public GameObject[] Slopes;
    public GameObject LoseScreen;
    public GameObject ScoreShower;

    [Header("Settings")]
    public float PlayerModeSpeed = 50;
    public float MaxForwardSpeed = 20;
    public float MaxSideSpeed = 20;
    public int PreSpawnedPlatforms = 3;
    public float GameSpeedModifier = 1;

    [Header("Game values")]
    public float CurrentSpeed = 50;
    public List<GameObject> SpawnedPlatforms;
    public float Score = 0;
    public bool IsDead = false;

    private GameObject spawnedHolder;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        spawnedHolder = new GameObject("SpawnedHolder");

        for (int i = 0; i < PreSpawnedPlatforms; i++)
        {
            SpawnNewPlatform();
        }

        PlayerRB = Player.transform.GetChild(0).GetComponent<Rigidbody>();

        LoseScreen.SetActive(false);

        //Debug.Log(new Marc());
        //Debug.Log(new Marc(true));
        //Debug.Log(new Marc(true, 40));
    }

    bool hasChanged = false;
    Rigidbody PlayerRB;
    private void Update()
    {
        if (!IsDead)
        {
            Score += ((Mathf.Abs(PlayerRB.velocity.z) + Mathf.Abs(PlayerRB.velocity.y)) * 0.5f) * Time.deltaTime;
            ScoreShower.GetComponent<Text>().text = System.Math.Round(Score).ToString();

            CurrentSpeed += Time.deltaTime * 0.01f;

            MaxForwardSpeed = CurrentSpeed / 25;
            MaxSideSpeed = CurrentSpeed / 25;

            PlayerModeSpeed = CurrentSpeed / 0.25f;
        }
        else
        {
            if (!hasChanged)
            {
                LoseScreen.SetActive(true);
                ScoreShower.SetActive(false);
                hasChanged = true;
            }
        }
    }

    public void SpawnNewPlatform(bool isStartingGame = false)
    {
        var objectToSpawn = Slopes[Random.Range(0, Slopes.Length)];
        var spawnPos = SpawnedPlatforms[SpawnedPlatforms.Count - 1].GetComponent<SlopeScript>().SpawnNextHere.transform.position;

        var spawnedPlatform = Instantiate(objectToSpawn, spawnPos, Quaternion.identity, spawnedHolder.transform) as GameObject;

        SpawnedPlatforms.Add(spawnedPlatform);

        if (!isStartingGame) return;

        Destroy(SpawnedPlatforms[0]);
        SpawnedPlatforms.RemoveAt(0);
    }

    public IEnumerator StartPlayerDeathSequence()
    {
        Player.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        Player.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;

        yield return new WaitForSecondsRealtime(1.5f);

        IsDead = true;
    }
}

public class Marc : Child
{
    public int Age { get; set; }
    public bool IsFurry { get; set; }

    public Marc()
    {
        IsAutistic = true;
        IsFurry = true;
        Age = 27;
    }

    public Marc(bool IsMark, int age = 3)
    {
        IsAutistic = IsMark;
        IsFurry = IsMark;

        if (IsMark)
        {
            Age = 29;
        }
        else
        {
            Age = age;
        }
    }
}

public class Child
{
    public bool IsAutistic { get; set; }
}
