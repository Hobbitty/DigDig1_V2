using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObject : MonoBehaviour
{

    public Rigidbody2D rBody;
    public float gravityTimer;
    public bool Touched = false;
    public Transform fallObject;
    public float speed = 1.0f;
    public float amount = 1.0f;
    private Vector2 startingPos;
    Vector2 P;
    public float magnitude;

    private void Awake()
    {
     
    }

    void Start()
    {
        rBody.bodyType = RigidbodyType2D.Static;
    }


    void Update()
    {

        if (Touched == true)
        {
          
            gravityTimer = gravityTimer + 1 * Time.deltaTime;
            if (gravityTimer >= 1)
            {
                rBody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Touched");
            Touched = true;
        }
    }

}
