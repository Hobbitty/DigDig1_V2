using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1Transition : MonoBehaviour
{

    public Transform playerPosition;
    public static bool frozen;
    public Rigidbody2D rBody;
    public Rigidbody2D bigEnemyRBody;
    public SpriteRenderer fade;
    public float fadeValue;
    public float timer;
    public bool fadeIn;
    public float timer2;
    public cameraShake cameraShake;
    public static bool doShake;
    public float timer3;


    void Start()
    {
        bigEnemyRBody.bodyType = RigidbodyType2D.Static;
        fadeValue = 0f;
        fadeValue = 1f;
        fadeIn = false;
        doShake = false;
    }

    void Update()
    {
        if (fadeIn == false)
        {
            fadeValue = fadeValue - 0.3f * Time.deltaTime;
            if (fadeValue <= 0)
            {
                fadeValue = 0;
                fadeIn = true;
            }

        }

        fade.color = new Color(0f, 0f, 0f, fadeValue);

        if (playerPosition.position.x >= 0)
        {
            frozen = true;
            rBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            timer2 = timer2 + 1 * Time.deltaTime;
            if (timer2 >= 1)
            {
                bigEnemyRBody.bodyType = RigidbodyType2D.Dynamic;
            }


        }
        if (frozen == true)
        {
            timer3 = timer3 + 1f * Time.deltaTime;
            if (timer3 >= 2f)
            {
                doShake = true;
            }

            timer = timer + 1 * Time.deltaTime;
            if (fadeIn == true)
            {
                if (timer >= 2)
                {
                    fadeValue = fadeValue + 0.2f * Time.deltaTime;
                    if (fadeValue >= 0.6f)
                    {
                        fadeValue = 1;
                    }
                }
            }
        }

    }

}
