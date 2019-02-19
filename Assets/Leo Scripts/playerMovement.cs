using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rbody;
    public float horizontalMovement;
    public float jumpHeight;
    public static bool playerIsAlive;
    


    void Start()
    {
        playerIsAlive = true;
    }

    void Update()
    {
        if (playerIsAlive == true)
        {
            if (enemyAttack.IsKnockbacked == false)
            {
                
                rbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbody.velocity.y);
                horizontalMovement = Input.GetAxis("Horizontal");

                if (Input.GetButtonDown("Jump"))
                {
                    rbody.velocity = new Vector2(rbody.velocity.x, jumpHeight);
                }
            }

        }

    }
}
