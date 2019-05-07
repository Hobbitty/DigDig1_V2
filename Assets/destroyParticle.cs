using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour
{

    public float timer;

    void Start()
    {

    }

    void Update()
    {
        timer = timer + 1 * Time.deltaTime;

        if (timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
