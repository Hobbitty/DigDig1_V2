using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingParticlesSloth : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GameObject bossSloth = GameObject.FindWithTag("Boss");
        SlothBoss boss2Script = bossSloth.GetComponent<SlothBoss>();
        if (boss2Script.isSleeping == false && boss2Script.sleepingTimer <= 0)
            Instantiate(gameObject, new Vector2(11, 3), transform.rotation);
        if (boss2Script.isSleeping == true && boss2Script.sleepingTimer <= 0)
            Destroy(gameObject);
        
        EnemyHealth bossSlothHealth = bossSloth.GetComponent<EnemyHealth>();
        if (bossSlothHealth.healthPoints <= 0)
            Destroy(gameObject);
    }
}
