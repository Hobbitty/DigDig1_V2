using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public int touches;
    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            touches += 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        touches -= 1;
    }
    private void Update()
    {
        if (touches > 0)
            isGrounded = true;
        else
            isGrounded = false;
    }
}
