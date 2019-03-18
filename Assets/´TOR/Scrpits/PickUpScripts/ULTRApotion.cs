using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTRApotion : MonoBehaviour
{
    public PlayerHP playerHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHP.numberOfHearts = 10;
            if (playerHP.hP < playerHP.numberOfHearts)
            {
                playerHP.hP = playerHP.numberOfHearts;
                if (playerHP.hP == 10)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
