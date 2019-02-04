using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int healthPoints;
    public float knockbackX;
    public float knockbackY;

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
            spriteRendEnemy.material.color = hitColor;
           
            
            rbodyEnemy.AddForce(new Vector2(knockbackX, knockbackY));
        }

    }

    IEnumerator Flash()
    {
        spriteRendEnemy.material.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        spriteRendEnemy.material.color = enemyColor;

    }

}
