using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHPReg : MonoBehaviour
{
    public PlayerHP playerHP;
    public bool touchesPlayer;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHP.hP < playerHP.numberOfHearts)
            {
                playerHP.hP = playerHP.numberOfHearts;
                Destroy(gameObject);
            }
        }
    }
}
