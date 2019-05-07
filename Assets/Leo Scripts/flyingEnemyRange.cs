using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemyRange : MonoBehaviour
{
    public static bool playerIsInRange;
    public Transform player;
    public float Range = 100f;
    public static float speed = 0.5f;
    private Vector2 smoothVelocity = Vector2.zero;
    public Rigidbody2D enemyRbody;
    public Transform spawnPoint;
 



    void Start()
    {
      
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
  
        if (distance < Range)
        {
            Range = 20f;
            playerIsInRange = true;

            transform.position = Vector2.SmoothDamp(transform.position, player.position, ref smoothVelocity, speed);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
