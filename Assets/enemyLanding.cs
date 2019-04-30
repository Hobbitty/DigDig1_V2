using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLanding : MonoBehaviour
{

    public AudioSource landingSound;
    public static bool playSound;

    void Start()
    {
        
    }

    void Update()
    {
        if (playSound == true)
        {
            landingSound.Play();
        }
    }
}
