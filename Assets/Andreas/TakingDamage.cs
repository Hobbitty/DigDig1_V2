using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    public int maxHP;
    public int currentHP;

    public int healthPoints;

    public GameObject damageFlash;


    // Start is called before the first frame update
    void Start()
    {
        damageFlash = GameObject.Find("PlayerDamageFlash");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyHurtBox")
        {
            currentHP--;
            Instantiate(damageFlash, transform.position, transform.rotation);
        }
    }

}
