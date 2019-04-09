using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Hurtboxes")]
    public GameObject attackHurtBoxForward;
    public GameObject attackHurtBoxUp;
    public GameObject attachHurtBoxDown;
    [Header("Transforms")]
    public Transform attackDirection;
    [Header("attackTimer")]
    public float attackTimer;
    public float attackTimerMaxValue;
    public bool canAttack;
    [Header("Ranged")]
    public GameObject projectile;
    public float rangedTimer;
    public float rangedTimerMaxValue;
    public bool canShoot;

    private Rigidbody2D rbodyPlayer;
    private bool lookingUp;
    private bool lookingDown;
<<<<<<< HEAD
    private Transform playerPos;
  
=======

>>>>>>> 9c7deae723226a35d8390edc95ec5301f8bff79e


    // Start is called before the first frame update
    void Start()
    {
        rbodyPlayer = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        playerPos = GetComponent<Transform>();
      
=======

>>>>>>> 9c7deae723226a35d8390edc95ec5301f8bff79e
    }

    // Update is called once per frame
    void Update()
    {
        CanAttackUp();
        CanAttackDown();
        Attacking();
        AttackingCooldown();
        RangedAttack();
    }

    void Attacking()
    {
        if (PlayerKnockback.IsKnockbacked || enemyAttack.IsKnockbacked == false)
        {
            if (Input.GetKeyDown(KeyCode.C) && lookingUp == false && lookingDown == false && canAttack == true)
            {
                Instantiate(attackHurtBoxForward, attackDirection);
                attackTimer = attackTimerMaxValue;
            }
            if (Input.GetKeyDown(KeyCode.C) && lookingUp == true && canAttack == true)
            {
                Instantiate(attackHurtBoxUp, attackDirection);
                attackTimer = attackTimerMaxValue;
            }

            GameObject groundCheck = GameObject.Find("GroundCheck");
            IsGrounded isAirborn = groundCheck.GetComponent<IsGrounded>();
            if (Input.GetKeyDown(KeyCode.C) && lookingDown == true && lookingUp == false
                && canAttack == true && isAirborn.isGrounded == false)
            {
                Instantiate(attachHurtBoxDown, attackDirection);
                attackTimer = attackTimerMaxValue;
<<<<<<< HEAD

                
=======
>>>>>>> 9c7deae723226a35d8390edc95ec5301f8bff79e
            }
        }
    }

    void CanAttackUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            lookingUp = true;
        }
        else
        {
            lookingUp = false;
        }

    }

    void CanAttackDown()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            lookingDown = true;
        }
        else
        {
            lookingDown = false;
        }
    }

    void AttackingCooldown()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            canAttack = true;
            attackTimer = 0;
        }
        else
        {
            canAttack = false;
        }
    }

    void RangedAttack()
    {
        if (rangedTimer <= 0)
        {
            rangedTimer = 0;
            canShoot = true;
        }
        else
        {
            rangedTimer -= Time.deltaTime;
            canShoot = false;
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (canShoot == true)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                rangedTimer = rangedTimerMaxValue;
            }
        }
    }
}
