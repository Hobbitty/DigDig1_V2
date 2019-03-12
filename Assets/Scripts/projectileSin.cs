using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSin : MonoBehaviour
{
    public float speed; //Space between waves'
    public float frequency;  // Speed of sine movement
    public float magnitude;   // Size of sine movement
    private Vector3 axis;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;

        // The direction of the wave, up = up and down, right = left and right
        axis = transform.up;
    }
    void Update()
    {
        //The direction of travel, -MoveSpeed = left
        pos += transform.right * Time.deltaTime * -speed;

        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

}
