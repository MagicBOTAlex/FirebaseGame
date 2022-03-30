using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;
    public GameObject[] Slopes;

    [Header("Settings")]
    public float PlayerModeSpeed = 50;
    public float MaxForwardSpeed = 20;
    public float MaxSideSpeed = 20;
    public int PreSpawnedPlatforms = 3;

    [Header("Game values")]
    public float CurrentSpeed = 50;
    public List<GameObject> SpawnedPlatforms;

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

        //Debug.Log(new Marc());
        //Debug.Log(new Marc(true));
        //Debug.Log(new Marc(true, 40));
    }

    public void SpawnNewPlatform()
    {
        SpawnedPlatforms.Add(Instantiate(Slopes[Random.Range(0, Slopes.Length)], SpawnedPlatforms[SpawnedPlatforms.Count - 1].GetComponent<SlopeScript>().SpawnNextHere.transform.position, Quaternion.identity, spawnedHolder.transform));
    }

    public IEnumerator StartPlayerDeathSequence()
    {
        Player.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        //Player.transform.GetChild(0).GetComponent<Rigidbody>().

        yield return null;
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
