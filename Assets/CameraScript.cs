using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    [Range(0, 1)]
    public float Weight = 1.0f;

    Transform tf;

    private void Start()
    {
        tf = Player.transform;
    }

    void Update()
    {
        transform.position = new Vector3(tf.position.x * Weight, tf.position.y, tf.position.z);
    }
}
