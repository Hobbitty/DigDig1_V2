using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterScript : MonoBehaviour
{
    public EnemyDetectionScript enemyDetectionScript;
    private SpriteRenderer rend;

    private void Update()
    {
        if (enemyDetectionScript.inRange == true)
        {
            
        }
    }
    void shoot()
    {

    }
}
