using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesStuck : MonoBehaviour
{

    public bool enemiesAreStuck;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if (player.transform.position.x >= 12)
        {
            enemiesAreStuck = true;
        }
    }

   

}
