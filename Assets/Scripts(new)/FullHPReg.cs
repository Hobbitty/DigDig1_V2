using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHPReg : MonoBehaviour
{
    public TakingDamage takeDMG;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (takeDMG.currentHP < takeDMG.maxHP)
            {
                takeDMG.currentHP = takeDMG.maxHP;
                Destroy(gameObject);
            }
        }
    }
}
