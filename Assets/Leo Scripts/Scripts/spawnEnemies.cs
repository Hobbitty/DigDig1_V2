using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public Transform playerPos;
    public float spawnPos;

    void Start()
    {
        enemy1.active = false;
        enemy2.active = false;
        enemy3.active = false;
        enemy4.active = false;
    }

    void Update()
    {
      if(playerPos.position.x >= spawnPos)
        {
            enemy1.active = true;
            enemy2.active = true;
            enemy3.active = true;
            enemy4.active = true;
        } 
    }
}
