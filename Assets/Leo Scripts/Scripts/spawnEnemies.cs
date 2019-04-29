using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;


    public Transform playerPos;
    public float spawnPos;

    private int enemyCountToSpawn = 3;

    void Start()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
    }

    void Update()
    {
        if (playerPos.position.x >= spawnPos)
        {
            enemy1.SetActive(true);

            for (int i = 0; i < enemyCountToSpawn; i++)
            {
                enemy2.SetActive(true);
            }
        }
    }
}
