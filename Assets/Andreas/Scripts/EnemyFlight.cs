using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlight : MonoBehaviour
{
    public float flightSpeed;

    private Rigidbody2D rbodyFlyer;

    private GameObject target;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        rbodyFlyer = GetComponent<Rigidbody2D>();

        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

    }

    private void FixedUpdate()
    {
        rbodyFlyer.velocity = (Vector2)(target.transform.position - currentPos).normalized * flightSpeed;
    }

 


}
