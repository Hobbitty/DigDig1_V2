using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHeart : MonoBehaviour
{

    public PlayerHP playerHP;
    public float addHeart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHP.hP < playerHP.numberOfHearts)
            {
                playerHP.hP = playerHP.hP + 1;
                Destroy(gameObject);
            }
            else
            {
                if (playerHP.numberOfHearts < 10)
                {
                    playerHP.numberOfHearts = playerHP.numberOfHearts + addHeart;
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Max Hearts reached")
                }
            }
        }
    }
}
