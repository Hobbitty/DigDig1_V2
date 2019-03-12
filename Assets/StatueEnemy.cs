using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueEnemy : MonoBehaviour
{

    public float fireFrequency;
    public GameObject fireProjectile;

    private float fireTimer;
    private Rigidbody2D privRbody;

    // Start is called before the first frame update
    void Start()
    {
        privRbody = GetComponent<Rigidbody2D>();
        fireTimer = fireFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;

        if(fireTimer <= 0)
        {
            Instantiate(fireProjectile, new Vector2(transform.position.x - 2, transform.position.y), transform.rotation);
            fireTimer = fireFrequency;
        }
    }
}
