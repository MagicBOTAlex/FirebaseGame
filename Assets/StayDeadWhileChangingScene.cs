using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayDeadWhileChangingScene : MonoBehaviour
{
    public void ChangeScene()
    {
        GameManager.KeepOldScore = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GettingGrass");
    }
}
