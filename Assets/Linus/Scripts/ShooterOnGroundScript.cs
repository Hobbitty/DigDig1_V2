using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterOnGroundScript : MonoBehaviour
{
    public int touches;

    private void OnTriggerEnter2D(Collider2D other)
    {
        touches += 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touches -= 1;
    }
}
