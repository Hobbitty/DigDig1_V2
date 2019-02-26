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
    public bool isLeft = true;
    public bool isOnGround;
    [Header("attacks")]
    public GameObject meleeAttack;
    public GameObject shockWave;
    public GameObject fallingObject;
    [Header("Attacking")]
    public float attackTimer;
    public float attackFrequency;
    public bool canAttack;
    public int numberOfAttacks;
    public int maxNumberOfAttacks;
    public float lastAttackTimer = 2;
    [Header("Rampage")]
    public int NumOfFallingObjects;
    [Header("Health")]
    public float healthTreshold;

    private Rigidbody2D rbodyBoss;

    private float actualMovementX;
    private float actualMovementY;

    private bool isMoving;
    private bool isAttacking;
    private bool doneAttacking = false;



    // Start is called before the first frame update
    void Start()
    {
        rbodyBoss = GetComponent<Rigidbody2D>();

        isAttacking = false;
        isMoving = true;

        attackTimer = attackFrequency;

        EnemyHealth bossHealth = gameObject.GetComponent<EnemyHealth>();
        healthTreshold = bossHealth.healthPoints / 2;

        NumOfFallingObjects = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
        Attacking();

        EnemyHealth bossHealth = gameObject.GetComponent<EnemyHealth>();
        if (bossHealth.healthPoints <= healthTreshold)
        {
            for (int r = 0; r < 1; r++)
            {
                maxNumberOfJumps += 1;
                maxNumberOfAttacks += 2;
                NumOfFallingObjects *= 2;
                attackFrequency /= 2;

                healthTreshold = 0;
            }
        }
    }

    void Jumping()
    {
        rbodyBoss.bodyType = RigidbodyType2D.Dynamic;
        if (isOnGround == true && jumpCounter < maxNumberOfJumps)
        {

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
                Instantiate(shockWave, new Vector3(transform.position.x, transform.position.y - 0.6f),
                    transform.rotation);
                for (int f = 0; f < NumOfFallingObjects; f++)
                {
                    Instantiate(fallingObject,
                    new Vector3(Random.Range(-10, 24), 16), transform.rotation);
                }
                attackTimer = attackFrequency;
                numberOfAttacks++;
            }
        }

        if (numberOfAttacks >= maxNumberOfAttacks)
        {
            lastAttackTimer -= Time.deltaTime;
            if (lastAttackTimer <= 0)
            {
                print("done attacking");
                doneAttacking = true;
                isAttacking = false;
                isMoving = true;
                attackTimer = attackFrequency;
                jumpCounter = 0;
                numberOfAttacks = 0;
                rbodyBoss.bodyType = RigidbodyType2D.Dynamic;
                lastAttackTimer = 2;
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            jumpCounter++;

            for (int i = 0; i < NumOfFallingObjects + 1; i++)
            {
                Instantiate(fallingObject,
                    new Vector3(Random.Range(-10, 24), 16), transform.rotation);
            }

            if (isLeft == true)
                maxMovementX = Random.Range(8, 11);
            else
                maxMovementX = Random.Range(-8, -11);

            maxMovemenY = Random.Range(20, 40);
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

