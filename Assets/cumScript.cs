using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cumScript : MonoBehaviour
{
    public GameObject door0;
    public GameObject door1;
    public GameObject door2;

    private void OnEnable()
    {
        switch (Random.Range(0,2))
        {
            case 0: Destroy(door0); break;
            case 1: Destroy(door1); break;
            case 2: Destroy(door2); break;
        }
    }
}
