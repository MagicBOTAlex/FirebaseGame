using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLabelShower : MonoBehaviour
{
    public GameObject Label;
    RectTransform tf;
    // Start is called before the first frame update
    void Start()
    {
        int amount = 10;
        tf = GetComponent<RectTransform>();

        for (int i = 0; i < amount; i++)
        {
            Instantiate(Label, new Vector3(0, -80 * (i+1), 0) + transform.position, Quaternion.identity, transform);
            tf.sizeDelta += new Vector2(0, 80);
        }
        tf.sizeDelta -= new Vector2(0, 80);
    }
}
