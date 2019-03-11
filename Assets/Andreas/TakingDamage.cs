using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakingDamage : MonoBehaviour
{
    [Header("HealthValues")]
    public int maxHP;
    public int currentHP;
    public int healthPoints;
    [Header("GameObjects")]
    public GameObject damageFlash;
    [Header("Death")]
    public string deathScene;
    [Header("MercyInvincibility")]
    public float mercyTimer;
    public float mercyFrequency;
    public bool canBeDamaged;
    public Color invincibleColor;

    private Color mainColor;
    private SpriteRenderer playerRend;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;

        canBeDamaged = true;
        mercyTimer = mercyFrequency;

        playerRend = GetComponent<SpriteRenderer>();
        mainColor = GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update()
    {
        MercyInvincibility();
        Dead();
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
        if (collision.gameObject.tag == "Boss" && canBeDamaged == true)
        {
            print("player damaged collider");
            currentHP--;

            canBeDamaged = false;

            Camera camera = Camera.main;
            Vector3 camTank = camera.transform.position;
            Instantiate(damageFlash, new Vector3(camTank.x, camTank.y, 0), transform.rotation);
        }
    }

    void Dead()
    {
        if (currentHP <= 0)
        {
            SceneManager.LoadScene(deathScene);
        }
    }

    void MercyInvincibility()
    {
        if (canBeDamaged == false)
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
}
