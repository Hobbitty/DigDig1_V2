using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public int timer;
    public static bool playerPickedUpAmmo;

    void Update()
    {
       if(timer >= 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timer = timer + 1;
            playerPickedUpAmmo = true;
           
        }
    }
}
