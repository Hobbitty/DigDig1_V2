using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
}
