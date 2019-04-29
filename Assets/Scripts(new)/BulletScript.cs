using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rBody;

    private Vector3 diff;
    private Transform playerTransform;
    private GameObject player;
    private GameObject parent;


    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Parent");
        gameObject.transform.parent = parent.transform;

        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        diff = playerTransform.transform.position - transform.position;
        diff.Normalize();
    }
    void FixedUpdate()
    {
        rBody.velocity = (diff * moveSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
