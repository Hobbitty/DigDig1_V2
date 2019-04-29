using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObstacle : MonoBehaviour
{
    public Sprite[] books;
    public int spriteDecider;


    private void Start()
    {
        spriteDecider = Random.Range(1, 5);

        GetComponent<SpriteRenderer>().sprite = books[spriteDecider - 1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
}
