using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTRApotion : MonoBehaviour
{
    public TakingDamage takeDMG;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            takeDMG.maxHP = 10;
            if (takeDMG.currentHP < takeDMG.maxHP)
            {
                takeDMG.currentHP = takeDMG.maxHP;
                if (takeDMG.maxHP == 10)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
