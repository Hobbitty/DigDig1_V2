using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Ammo")]
    public int maxAmmo = 30;
    public int currentAmmo;
    public TextMeshProUGUI displayAmmo;

    [Header("Animation")]
    public Animator playerAnimator;

    [Header("Other")]
    private Rigidbody2D rbodyPlayer;
    private bool lookingUp;
    private bool lookingDown;
    public int timer;
    public bool enemyHit;
    public AudioSource hit;
    public AudioSource hitStick;
    public float animTimer;
    public bool attackAnimation;


    private Transform playerPos;




    // Start is called before the first frame update
    void Start()
    {
        rbodyPlayer = GetComponent<Rigidbody2D>();

        playerPos = GetComponent<Transform>();

        currentAmmo = maxAmmo;
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


        if (Input.GetKeyDown(KeyCode.C) && lookingUp == false && lookingDown == false && canAttack == true)
        {
            Instantiate(attackHurtBoxForward, attackDirection);
            attackTimer = attackTimerMaxValue;
            hitStick.Play();
            playerAnimator.SetBool("attacking", true);
           



        }
        if (Input.GetKeyDown(KeyCode.C) && lookingUp == true && canAttack == true)
        {
            Instantiate(attackHurtBoxUp, attackDirection);
            attackTimer = attackTimerMaxValue;
            hitStick.Play();
        }

        GameObject groundCheck = GameObject.Find("GroundCheck");
        IsGrounded isAirborn = groundCheck.GetComponent<IsGrounded>();
        if (Input.GetKeyDown(KeyCode.C) && lookingDown == true && lookingUp == false
            && canAttack == true && isAirborn.isGrounded == false)
        {
            Instantiate(attachHurtBoxDown, attackDirection);
            attackTimer = attackTimerMaxValue;

            hitStick.Play();



            //rbodyPlayer.velocity = transform.up * 10;

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
            if (canShoot == true & currentAmmo > 0)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                rangedTimer = rangedTimerMaxValue; hit.Play();
                currentAmmo = currentAmmo - 1;
            }
        }

        displayAmmo.text = string.Format("AMMO: {0}", currentAmmo);

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        if (destroy.playerPickedUpAmmo == true)
        {
            currentAmmo = currentAmmo + 10;
            destroy.playerPickedUpAmmo = false;
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyHurtBox")
        {
            enemyHit = true;

        }
    }



}

