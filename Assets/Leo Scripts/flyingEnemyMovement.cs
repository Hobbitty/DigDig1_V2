using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemyMovement : MonoBehaviour
{
    public static bool left;
    public bool mobAlive;
    public Rigidbody2D rBody;
    public int speed;
   
    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flyingEnemyRange.playerIsInRange == false)
        {
            if (collision.tag == ("invisiblewall"))
            {
                left = !left;
            }
        }

    }


    private void FixedUpdate()
    {
        if (mobAlive == true)
        {

            if (flyingEnemyRange.playerIsInRange == false)
            {
                if (left == true)
                {
                    rBody.velocity = -(Vector2)transform.right * Time.deltaTime * speed;
                    transform.localScale = new Vector3(0.5f, 0.4f, 0.5f);
                }
                else
                {
                    rBody.velocity = (Vector2)transform.right * Time.deltaTime * speed;
                    transform.localScale = new Vector3(-0.5f, 0.4f, 0.5f);
                }

            }
            else
            {
                rBody.velocity = (new Vector2(0, 0));
            }

        }


    }


}





