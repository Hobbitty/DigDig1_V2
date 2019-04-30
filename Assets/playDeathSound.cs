using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDeathSound : MonoBehaviour
{

    public AudioSource deathSound;

    void Start()
    {
        
    }

    void Update()
    {
        if(TakingDamage.dead == true)
        {
            deathSound.Play();
            print("DeathSound");
        }
    }
}
