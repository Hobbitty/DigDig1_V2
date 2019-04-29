using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmissionScript : MonoBehaviour
{
    public GameObject particle;

    private IsGrounded groundCheck;
    private bool spawnParticle;

    private void Start()
    {
        groundCheck = gameObject.GetComponentInParent<IsGrounded>();
    }
    private void Update()
    {
        if(groundCheck.isGrounded == true)
        {
            if (spawnParticle == true)
            {
                GameObject newObject = Instantiate(particle, transform);
                //Destroy(newObject, 1f);
                spawnParticle = false;
            }
        }
        if(groundCheck.isGrounded == false)
        {
            spawnParticle = true;
        }
    }
}
