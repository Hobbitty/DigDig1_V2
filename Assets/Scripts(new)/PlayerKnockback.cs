using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{

    public float knockBackReset;
    public Transform playerPosition;
    public Rigidbody2D rBody;
    public Vector2 knockbackDirection;
    public static bool IsKnockbacked;
    private Transform enemyPosition;
    public SpriteRenderer playerSprite;
    public float knockbackValue;

    void Start()
    {
        enemyPosition = GetComponent<Transform>();
        knockBackReset = 0;
        IsKnockbacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyPosition.position;
        knockbackDirection = playerPosition.transform.position - enemyPosition.transform.position;
        if (IsKnockbacked == true)
        {
            knockBackReset = knockBackReset + 1f * Time.deltaTime;
        }
        if (knockBackReset >= 1)
        {
            knockBackReset = 0;
            IsKnockbacked = false;
        }

        if (IsKnockbacked == true)
        {
            //playerSprite.color = new Color(0.8301887f, 0.8106087f, 0.8106087f, 0.5294118f);
        }
        else
        {
            //playerSprite.color = new Color(1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (IsKnockbacked == false)
            {

                print("Player Has Been Damaged");
                rBody.AddForce(knockbackDirection * knockbackValue);

            }


            IsKnockbacked = true;

            if (playerPosition.position.x <= enemyPosition.position.x)
            {
                print("PlayerHasBeenKnockedBackLeft");

            }

            if (playerPosition.position.x > enemyPosition.position.x)
            {
                print("PlayerHasBeenKnockedBackRight");

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (IsKnockbacked == false)
            {

                print("Player Has Been Damaged");
                rBody.AddForce(knockbackDirection * knockbackValue);

            }


            IsKnockbacked = true;

            if (playerPosition.position.x <= enemyPosition.position.x)
            {
                print("PlayerHasBeenKnockedBackLeft");

            }

            if (playerPosition.position.x > enemyPosition.position.x)
            {
                print("PlayerHasBeenKnockedBackRight");

            }
        }
    }
}

