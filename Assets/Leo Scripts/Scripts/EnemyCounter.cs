using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemies;
    public int enemiesRemaining;
    public int deadEnemies;


    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;

        deadEnemies = 0 - enemiesRemaining + totalEnemies;
    }
}
