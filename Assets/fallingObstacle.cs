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

        if (spriteDecider == 1)
            GetComponent<SpriteRenderer>().sprite = books[0];
        if (spriteDecider == 2)
            GetComponent<SpriteRenderer>().sprite = books[1];
        if (spriteDecider == 3)
            GetComponent<SpriteRenderer>().sprite = books[2];
        if (spriteDecider == 4)
            GetComponent<SpriteRenderer>().sprite = books[3];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
}
