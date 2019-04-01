﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniBossDoor : MonoBehaviour
{

    public GameObject miniBoss;
    public bool miniBossAlive;
    public BoxCollider2D door;
    public string sceneToLoad;
    public bool ContinueOnLevel;


    void Start()
    {

    }


    void Update()
    {


        if (miniBoss.active == true)
        {
            miniBossAlive = true;
        }
      

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && miniBossAlive == false)
        {
            if (ContinueOnLevel == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
            if (ContinueOnLevel == true)
            {
                door.enabled = false;
            }
        }
    }
}



