using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour
{
    private void OnEnable()
    {
        var score = GameManager.Instance.Score;
        GetComponent<Text>().text = System.Math.Round(score, 2).ToString();
    }
}
