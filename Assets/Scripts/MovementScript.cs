using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;
    public float MovementSpeed = 100;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), rb.velocity.y, 0) * MovementSpeed;
    }
}
