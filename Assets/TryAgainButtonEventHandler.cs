using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButtonEventHandler : MonoBehaviour
{
    public void Clicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GettingGrass");
    }
}
