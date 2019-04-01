using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHPReg : MonoBehaviour
{
    public int addHP = 1;
    public TakingDamage healthLoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (healthLoss.currentHP < healthLoss.maxHP)
            {
                healthLoss.currentHP = healthLoss.currentHP + addHP;
                Debug.Log("Healed");
                Destroy(gameObject);
            }
        }
    }
}