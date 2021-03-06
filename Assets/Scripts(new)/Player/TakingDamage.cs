﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakingDamage : MonoBehaviour
{
    [Header("HealthValues")]
    public int maxHP;
    public int currentHP;
    [Header("GameObjects")]
    public GameObject damageFlash;
    [Header("Death")]
    public string deathScene;
    public int lvlPlayerDiedOn = 1;
    [Header("MercyInvincibility")]
    public float mercyTimer;
    public float mercyFrequency;
    public bool canBeDamaged;

    public Color invincibleColor;

    private Color mainColor;
    private SpriteRenderer playerRend;
    public bool debugInvincibility;

    public float knockBackReset;
    public Transform playerPosition;
    public Rigidbody2D rBody;
    public Vector2 knockbackDirection;
    public static bool IsKnockbacked;
    public Transform enemyPosition;
    public float knockbackValue;
    public float timer;
    public static bool dead;
    public AudioSource deathSound;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;

        canBeDamaged = true;
        mercyTimer = mercyFrequency;

        playerRend = GetComponent<SpriteRenderer>();
        mainColor = GetComponent<SpriteRenderer>().color;

        lvlPlayerDiedOn += 1;
    }

    // Update is called once per frame
    void Update()
    {
        MercyInvincibility();
        Dead();

        DebugInvincibility();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyHurtBox" && canBeDamaged == true)
        {
            print("player damaged trigger");
            currentHP--;

            canBeDamaged = false;

            Camera camera = Camera.main;
            Vector3 camTank = camera.transform.position;
            Instantiate(damageFlash, new Vector3(camTank.x, camTank.y, 0), transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss" && canBeDamaged == true
            || collision.gameObject.tag == "Enemy " && canBeDamaged == true)
        {
            print("player damaged collider");
            currentHP--;

            canBeDamaged = false;

            Camera camera = Camera.main;
            Vector3 camTank = camera.transform.position;
            Instantiate(damageFlash, new Vector3(camTank.x, camTank.y, 0), transform.rotation);
        }

        if (collision.gameObject.tag == "Enemy" && canBeDamaged == true)
        {
            print("player damaged collider");
            currentHP--;

            canBeDamaged = false;

            Camera camera = Camera.main;
            Vector3 camTank = camera.transform.position;
            Instantiate(damageFlash, new Vector3(camTank.x, camTank.y, 0), transform.rotation);
        }

        //knockbackDirection = playerPosition.transform.position - enemyPosition.transform.position;
        if (IsKnockbacked == true)
        {
            knockBackReset = knockBackReset + 1f * Time.deltaTime;
        }
        if (knockBackReset >= 1)
        {
            knockBackReset = 0;
            IsKnockbacked = false;
        }

        if (collision.gameObject.tag == "Killplane")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void Dead()
    {
        if (currentHP <= 0)
        {
            rBody.constraints = RigidbodyConstraints2D.None;
            timer = timer + 1 * Time.deltaTime;
            dead = true;
            playerAnimator.SetBool("frozen", true);
            deathSound.Play();
            if (timer >= 3)
            {
                SceneManager.LoadScene(deathScene);
            }


        }
    }

    void MercyInvincibility()
    {
        if (canBeDamaged == false && debugInvincibility == false)
        {
            mercyTimer -= Time.deltaTime;

            playerRend.color = invincibleColor;
        }

        if (mercyTimer <= 0)
        {
            canBeDamaged = true;
            mercyTimer = mercyFrequency;
            playerRend.color = mainColor;
        }
    }

    void DebugInvincibility()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            debugInvincibility = !debugInvincibility;
            canBeDamaged = !debugInvincibility;
        }

    }
}
