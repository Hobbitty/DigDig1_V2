using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScenePicture : MonoBehaviour
{
    public float travelSpeed;
    public Vector2 startPose;
    public Vector2 endPose;

    public Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        transform.position = startPose;
    }

    // Update is called once per frame
    void Update()
    {
        rbody.AddForce(transform.forward * travelSpeed* Time.deltaTime);
    }
}
