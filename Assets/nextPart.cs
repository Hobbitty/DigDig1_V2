using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPart : MonoBehaviour
{

    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(18f, -2.3f);
        }

        CameraFollow.secondPos = true;

    }
}
