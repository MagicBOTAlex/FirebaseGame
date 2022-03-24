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

        for (int i = 0; i < PreSpawnedPlatforms; i++)
        {
            SpawnNewPlatform();
        }
    }

    public void SpawnNewPlatform()
    {
        SpawnedPlatforms.Add(Instantiate(Slopes[Random.Range(0, Slopes.Length)], SpawnedPlatforms[SpawnedPlatforms.Count - 1].GetComponent<SlopeScript>().SpawnNextHere.transform.position, Quaternion.identity));
    }
}
