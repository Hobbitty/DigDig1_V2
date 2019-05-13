using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public string sceneToLoad = "level1";
    public Animator playerAnimator;


    void Start()
    {
        bigEnemyRBody.bodyType = RigidbodyType2D.Static;

        fadeValue = 1f;
        fadeIn = false;
        doShake = false;
    }

    void Update()
    {

        if (doShake == true)
        {
            print("Shake");
        }

        if (fadeIn == false)
        {
            fadeValue = fadeValue - 0.3f * Time.deltaTime;
            if (fadeValue <= 0)
            {
                fadeValue = 0;
                fadeIn = true;
            }

        }

        print(fadeValue);

        fade.color = new Color(0f, 0f, 0f, fadeValue);

        if (playerPosition.position.x >= 0)
        {
            playerAnimator.SetBool("frozen", true);
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
                enemyLanding.playSound = true;
                fadeValue = fadeValue + 0.2f * Time.deltaTime;
                if (fadeValue >= 0.6f)
                {
                    fadeValue = 1;
                }
            }

            /*  if(timer3 >= 3)
              {
                  SceneManager.LoadScene(sceneToLoad);
              }

              timer = timer + 1 * Time.deltaTime;
              if (fadeIn == true)
              {
                  if (timer >= 2)
                  {

                  } */
        }
    }

}

