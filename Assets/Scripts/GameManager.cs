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

    [Header("Game values")]
    public float CurrentSpeed = 50;

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
    }
}
