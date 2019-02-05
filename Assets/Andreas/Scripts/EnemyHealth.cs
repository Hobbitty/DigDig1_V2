using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("healt and knockback")]
    public int healthPoints;
    public float knockbackX;
    public float knockbackY;
    [Header("death effect")]
    public ParticleSystem deathEffect;

    private Rigidbody2D rbodyEnemy;
    private SpriteRenderer spriteRendEnemy;
    private Color enemyColor;
    private Color hitColor = Color.black;


    // Start is called before the first frame update
    void Start()
    {
        rbodyEnemy = GetComponent<Rigidbody2D>();
        spriteRendEnemy = GetComponent<SpriteRenderer>();
        enemyColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            print("enemy killed");
            DeathEffect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHurtBox")
        {
            print("enemy hit");
            AttackPhysics wep = collision.gameObject.GetComponent<AttackPhysics>();
            healthPoints -= wep.damage;

            StartCoroutine(Flash());

            rbodyEnemy.AddForce(new Vector2(knockbackX, knockbackY));
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
    }

}
