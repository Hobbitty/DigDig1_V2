using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHeart : MonoBehaviour
{
    public PlayerHP playerHP;
    public float addHeart;
    public bool allowHp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((playerHP.hP < playerHP.numberOfHearts) && (allowHp == true))
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
                    if (playerHP.numberOfHearts > 10)
                    {
                        playerHP.numberOfHearts = 10;
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