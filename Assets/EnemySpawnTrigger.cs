using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public Vector2 minSpawnPoint;
    public Vector2 maxSpawnPoint;
    public int enemyCountToSpawn;
    private bool hasBeenTriggered;

    private void Start()
    {
        hasBeenTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && hasBeenTriggered == false)
        {
            for (int i = 0; i < enemyCountToSpawn; i++)
            {
                Instantiate(enemyToSpawn,
                    new Vector2(Random.Range(minSpawnPoint.x, maxSpawnPoint.x), Random.Range(minSpawnPoint.y, maxSpawnPoint.y))
                    , transform.rotation);
            }
            hasBeenTriggered = true;
        }
    }

}
