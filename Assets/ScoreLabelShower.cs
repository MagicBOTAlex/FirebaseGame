using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Linq;
using System;

public class ScoreLabelShower : MonoBehaviour
{
    public GameObject Label;
    RectTransform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<RectTransform>();

        DatabaseStructure data = FirebaseHandler.GetData();
        if (data is null) return;
        data.Scores = data.Scores.OrderByDescending(x => x.Score).ToArray();

        float currentPos = 0;
        for (int i = 0; i < data.Scores.Length; i++)
        {
            GameObject scoreLabel;
            if (i == 0)
            {
                currentPos = 100;
                tf.sizeDelta += new Vector2(0, 60);
                scoreLabel = Instantiate(Label, new Vector3(0, -currentPos, 0) + transform.position, Quaternion.identity, transform);
            }
            else
            {
                currentPos += 65;
                tf.sizeDelta += new Vector2(0, 70);
                scoreLabel = Instantiate(Label, new Vector3(0, -currentPos, 0) + transform.position, Quaternion.identity, transform);
            }

            var labelObjects = scoreLabel.GetComponent<ScoreLabelScript>();
            labelObjects.Label.GetComponent<Text>().text = data.Scores[i].Name;
            labelObjects.LabelScore.GetComponent<Text>().text = data.Scores[i].Score.ToString();
        }
        //tf.sizeDelta -= new Vector2(0, 80);
    }
}
