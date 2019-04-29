using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHeart : MonoBehaviour
{
    public TakingDamage takeDMG;
    public int addHeart;
    public bool allowHp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((takeDMG.currentHP < takeDMG.maxHP) && (allowHp == true))
            {
                takeDMG.currentHP = takeDMG.currentHP + 1;
                Destroy(gameObject);
            }
            else
            {
                if (takeDMG.maxHP < 10)
                {
                    takeDMG.maxHP = takeDMG.maxHP + addHeart;
                    Destroy(gameObject);
                }
                else
                {
                    if (takeDMG.maxHP > 10)
                    {
                        takeDMG.maxHP = 10;
                        Debug.Log("Max Hearts reached");
                    }
                    else
                    {
                        Debug.Log("Max Hearts reached");
                    }
                }
            }
        }
    }
    private void Update()
    {
        HealAllow();
    }

    //Bara för testing
    public void HealAllow()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (allowHp == true)
            {
                allowHp = false;
            }
            else
            {
                allowHp = true;
            }
        }
    }
}