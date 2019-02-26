using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHPReg : MonoBehaviour
{
    public PlayerHP playerHP;
    public bool touchesPlayer;
    public float addHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHP.hP < playerHP.numberOfHearts)
            {
                playerHP.hP = playerHP.hP + addHP;
                Destroy(gameObject);
            }
        }
    }
}