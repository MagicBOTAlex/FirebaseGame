using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal") * GameManager.Instance.PlayerModeSpeed * Time.deltaTime, 0, 0));
        rb.AddForce(new Vector3(0, 0, GameManager.Instance.CurrentSpeed * Time.deltaTime));

        if (rb.velocity.z > GameManager.Instance.MaxForwardSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, GameManager.Instance.MaxForwardSpeed);
        }
        if (rb.velocity.x > GameManager.Instance.MaxSideSpeed)
        {
            rb.velocity = new Vector3(GameManager.Instance.MaxSideSpeed, rb.velocity.y, rb.velocity.z);
        }
    }
}
