using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rBody;

    private Transform playerTransform;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 diff = playerTransform.transform.position - transform.position;
        diff.Normalize();
        rBody.velocity = (diff * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
