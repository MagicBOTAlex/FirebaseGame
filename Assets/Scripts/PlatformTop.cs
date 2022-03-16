using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Instantiate((GameObject)Resources.Load("Platform"));
    }
}
