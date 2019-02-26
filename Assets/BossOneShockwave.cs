using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneShockwave : MonoBehaviour
{
    public float travelSpeed;

    // Update is called once per frame
    void Update()
    {
        GameObject bossOne = GameObject.Find("Boss1");
        BossOne bossOneScript = bossOne.GetComponent<BossOne>();
        if (bossOneScript.isLeft == true)
            transform.Translate(new Vector3(travelSpeed * Time.deltaTime, 0));
        else
            transform.Translate(new Vector3(-travelSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}