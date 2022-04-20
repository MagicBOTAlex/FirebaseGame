using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneToScene : MonoBehaviour
{
    public void Clicked(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
