using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHPReg : MonoBehaviour
{
    public PlayerHP playerHP;
    public RegularHPReg hpReg;
    public bool touchesPlayer;

    private void Start()
    {
        hpReg.addHP = playerHP.numberOfHearts;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHP.hP < playerHP.numberOfHearts)
            {
                playerHP.hP = hpReg.addHP;
                Destroy(gameObject);
            }
        }
    }
}
