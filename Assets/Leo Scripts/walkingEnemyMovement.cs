using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingEnemyMovement : MonoBehaviour
{

    public float speed = 1;
    public Transform playerPosition;
    public float enemyRange  = 10f;
    private Vector2 smoothVelocity = Vector2.zero;
   

    void Start()    
    {
        
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition.position);
        if(distance < enemyRange)
        {
            transform.position = Vector2.SmoothDamp(transform.position, playerPosition.position, ref smoothVelocity, speed);
        }
    }
}
