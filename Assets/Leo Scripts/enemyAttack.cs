using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    public int enemyBaseDmg;
    public float dmgMultiplier;
    public float playerMaxHp = 100;
    public SpriteRenderer playerSprite;
    public Transform enemyPosition;
    public float currentPlayerHp;
    public float knockBackReset;
    public Transform playerPosition;
    public Rigidbody2D rBody;
    public Vector2 knockbackDirection;
    public static bool IsKnockbacked;

    public PlayerHP playerHP;

    void Start()
    {
        currentPlayerHp = playerMaxHp;
        knockBackReset = 0;
        IsKnockbacked = false;

    }

    private void Update()
    {
        HP();

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
            playerSprite.color = new Color(0.8301887f, 0.8106087f, 0.8106087f, 0.5294118f);
        }
        else
        {
            playerSprite.color = new Color(1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (IsKnockbacked == false)
            {
                playerHP.hP = currentPlayerHp - (enemyBaseDmg * dmgMultiplier);
                print("Player Has Been Damaged");
            }

            print(currentPlayerHp);
            IsKnockbacked = true;
            rBody.AddForce(knockbackDirection * 300);

            if (playerPosition.position.x <= enemyPosition.position.x)
            {
                print("PlayerHasBeenKnockedBackLeft");

            }

            if (playerPosition.position.x > enemyPosition.position.x)
            {
                print("PlayerHasBeenKnockedBackRight");

            }
        }

        if (currentPlayerHp <= 0)
        {
            print("Player Has Been Killed");
            playerSprite.color = new Color(0.4625756f, 0.4964368f, 0.5524653f);
            LeoPlayerMovement.playerIsAlive = false;
        }
        else
        {
            LeoPlayerMovement.playerIsAlive = true;
        }

    }

    void HP()
    {
        //currentPlayerHp = playerHP.hP;
    }
}
