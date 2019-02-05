using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeCheck : MonoBehaviour
{
    public ShooterEnemyScript shooterEnemyScript;

    public GameObject projectile;
    public bool inRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
        InvokeRepeating("Shoot", shooterEnemyScript.chargeTime, shooterEnemyScript.chargeTime);
 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        CancelInvoke();
    }

    void Shoot()
    {
        Instantiate(projectile, transform);
    }
}
