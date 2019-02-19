using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOne : MonoBehaviour
{
    [Header("Movement")]
    public float maxMovementX;
    public float maxMovemenY;
    public int jumpCounter;
    public int maxNumberOfJumps;
    [Header("attacks")]
    public GameObject meleeAttack;
    public GameObject rangedAttack;
    [Header("Attacking")]
    public float attackTimer;
    public float attackFrequency;
    public bool canAttack;
    public int numberOfAttacks;
    public int maxNumberOfAttacks;
    
    private Rigidbody2D rbodyBoss;

    private float actualMovementX;
    private float actualMovementY;

    public bool isMoving;
    public bool isAttacking;
    public bool isOnGround;
    public bool isLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        rbodyBoss = GetComponent<Rigidbody2D>();

        attackTimer = attackFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround == true && jumpCounter < maxNumberOfJumps)
        {
            rbodyBoss.bodyType = RigidbodyType2D.Dynamic;
            Jumping();
        }

        if (jumpCounter >= maxNumberOfJumps)
        {

            rbodyBoss.bodyType = RigidbodyType2D.Static;

            isAttacking = true;
            isMoving = false;

            Attacking();
        }

    }

    void Jumping()
    {
        actualMovementX = maxMovementX;
        actualMovementY = maxMovemenY;

        isMoving = true;
        rbodyBoss.velocity = new Vector2(actualMovementX, actualMovementY);
    }

    void Attacking()
    {
        if (attackTimer <= 0)
            canAttack = true;
        else
            canAttack = false;

        if (isAttacking == true && isMoving == false)
        {
            attackTimer -= Time.deltaTime;

            if (canAttack == true)
            {
                Instantiate(meleeAttack, transform.position, transform.rotation);
                attackTimer = attackFrequency;
                numberOfAttacks++;
            }

        }

        if(numberOfAttacks > maxNumberOfAttacks)
        {
            isAttacking = false;
            isMoving = true;
        }


    }

    void Rampage()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            isOnGround = true;
            jumpCounter++;
        }

        if (collision.gameObject.tag == "Wall")
        {
            if (isLeft == true)
            {
                transform.localScale = new Vector2(4, 4);
                isLeft = false;
            }
            if (isLeft == false)
            {
                transform.localScale = new Vector2(-4, 4);
                isLeft = true;
            }

            actualMovementX *= -1;
            maxMovementX *= -1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isOnGround = false;
    }
}
