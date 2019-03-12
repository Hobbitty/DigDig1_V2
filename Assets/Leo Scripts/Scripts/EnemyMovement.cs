using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rbodyEnemy;


    // Start is called before the first frame update
    void Start()
    {
        rbodyEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed <= 0)
            transform.eulerAngles = new Vector2(0, 0);
        else
            transform.eulerAngles = new Vector2(0, 180);

    }

    private void FixedUpdate()
    {
        rbodyEnemy.velocity = new Vector2(moveSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            moveSpeed *= -1;
    }

}
