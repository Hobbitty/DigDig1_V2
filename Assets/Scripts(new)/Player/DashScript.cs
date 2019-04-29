using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    public float dashSpeed;

    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            rBody.velocity = transform.forward * dashSpeed;
    }
}
