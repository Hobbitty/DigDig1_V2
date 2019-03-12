using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{

    public Rigidbody2D rBody;
    public Transform playerPos;
    public float dropZone;
    bool boulderIsGrounded = false;
    public float speed;
    public float spinningSpeed;

    void Start()
    {
        rBody.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (playerPos.position.x >= dropZone)
        {
            //transform.localRotation = ()
            rBody.bodyType = RigidbodyType2D.Dynamic;
            if (boulderIsGrounded == true)
            {
                rBody.velocity = (Vector2)transform.right * Time.deltaTime * speed;
                transform.localScale = new Vector3(6, 6, 6);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boulderIsGrounded = true;
    }
}
