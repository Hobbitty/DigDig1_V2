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
    public bool isLeft = true;
    public bool doneAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        rbodyBoss = GetComponent<Rigidbody2D>();

        isAttacking = false;
        isMoving = true;

        attackTimer = attackFrequency;


    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
        Attacking();
    }

    void Jumping()
    {

        if (isOnGround == true && jumpCounter < maxNumberOfJumps)
        {
            rbodyBoss.bodyType = RigidbodyType2D.Dynamic;

            actualMovementX = maxMovementX;
            actualMovementY = maxMovemenY;

            isMoving = true;
            rbodyBoss.velocity = new Vector2(actualMovementX, actualMovementY);
        }

        if (jumpCounter >= maxNumberOfJumps)
        {

            rbodyBoss.bodyType = RigidbodyType2D.Static;

            isAttacking = true;
            isMoving = false;
            if (isAttacking == true)
                Attacking();
        }
    }

    void Attacking()
    {
        doneAttacking = false;

        if (attackTimer <= 0)
            canAttack = true;
        else
            canAttack = false;

        if (isAttacking == true && isMoving == false)
        {
            attackTimer -= Time.deltaTime;

            if (canAttack == true && doneAttacking == false)
            {
                Instantiate(meleeAttack, transform.position, transform.rotation);
                attackTimer = attackFrequency;
                numberOfAttacks++;
            }
        }

        if (numberOfAttacks >= maxNumberOfAttacks)
        {
            print("done attacking");
            doneAttacking = true;
            isAttacking = false;
            isMoving = true;
            attackTimer = attackFrequency;
            jumpCounter = 0;
            numberOfAttacks = 0;
            rbodyBoss.bodyType = RigidbodyType2D.Dynamic;


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
            print(collision.gameObject.tag);

            if (isLeft == true)
                isLeft = false;
            else
                isLeft = true;


            if (isLeft == true)
                transform.localScale = new Vector2(-0.8f, 0.8f);
            else
                transform.localScale = new Vector2(0.8f, 0.8f);


            actualMovementX *= -1;
            maxMovementX *= -1;

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isOnGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isOnGround = false;

    }
}

