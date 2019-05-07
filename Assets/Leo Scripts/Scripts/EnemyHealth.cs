using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health and Knockback")]
    public int healthPoints;
    public float knockbackX;
    public float knockbackY;
    [Header("Death Effect")]
    public ParticleSystem deathEffect;

    private Rigidbody2D rbodyEnemy;
    private SpriteRenderer spriteRendEnemy;
    private Color enemyColor;
    private Color hitColor = Color.black;
    private int timer = 0;
    private Transform enemyPos;
    public bool miniBossEnemy;
    public AudioSource enemyDeathSound;
    public float enemyDeathTimer;
    public AudioSource enemyHurtsound;



    // Start is called before the first frame update
    void Start()
    {
        rbodyEnemy = GetComponent<Rigidbody2D>();
        spriteRendEnemy = GetComponent<SpriteRenderer>();
        enemyColor = GetComponent<SpriteRenderer>().color;
        enemyPos = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        if (healthPoints <= 0)
        {
            if (miniBossEnemy == false)
            {
                Destroy(gameObject);
            }
            else
            {
                enemyPos.position = new Vector2(100f, 100f);
                miniBossDoor.miniBossAlive = false;
            }

            
            enemyDeathSound.Play();
            DeathEffect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHurtBox")
        {
            AttackPhysics wep = collision.gameObject.GetComponent<AttackPhysics>();
            healthPoints -= wep.damage;
            enemyHurtsound.Play();

            StartCoroutine(Flash());

            rbodyEnemy.AddForce(new Vector2(knockbackX, knockbackY));

            platformEnemyScript.active = false;
            timer = timer + 1;
            if (timer > 1)
            {
                platformEnemyScript.active = true;
                timer = 0;
            }
        }

    }

    IEnumerator Flash()
    {
        spriteRendEnemy.material.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        spriteRendEnemy.material.color = enemyColor;

    }

    void DeathEffect()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        /*Instantiate(enemyDeathSound, transform.position.normalized, transform.rotation);*/
    }

}
