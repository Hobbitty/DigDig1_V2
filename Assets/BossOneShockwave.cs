using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneShockwave : MonoBehaviour
{
    public float travelSpeed;

    private void Start()
    {
        GameObject bossOne = GameObject.Find("Boss1");
        BossOne bossOneScript = bossOne.GetComponent<BossOne>();
        if (bossOneScript.isLeft == false)
            travelSpeed *= -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(travelSpeed * Time.deltaTime, 0));


        GameObject bossOne = GameObject.Find("Boss1");
        EnemyHealth bossOneHealth = bossOne.GetComponent<EnemyHealth>();
        if (bossOneHealth.healthPoints <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}