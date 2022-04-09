using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneToLeaderBoards : MonoBehaviour
{
    public void Clicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LeaderBoard");
    }
}
