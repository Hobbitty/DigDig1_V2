using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformEnemyScript : MonoBehaviour
{

    public bool left;
    public Rigidbody2D rBody;
    public int speed;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "invisiblewall")
        {
            left = !left;
        }
    }

    private void FixedUpdate()
    {
        if(left == true)
        {
            rBody.velocity = -(Vector2)transform.right * Time.deltaTime * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rBody.velocity = (Vector2)transform.right * Time.deltaTime * speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
