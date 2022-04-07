using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    Rigidbody rb;

    private void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = Player.transform.position + Vector3.RotateTowards(transform.position - Player.transform.position, -Player.GetComponent<Rigidbody>().velocity.normalized * 2, Time.deltaTime, .0f);
    }
}
