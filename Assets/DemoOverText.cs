using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DemoOverText : MonoBehaviour
{
    public GameObject DemoOverCanvas;

    public float timer = 5;

    // Update is called once per frame
    void Update()
    {
        GameObject theBoss = GameObject.FindWithTag("Boss");
        if (theBoss != null)
        {
            EnemyHealth bossHP = theBoss.GetComponent<EnemyHealth>();
            {
                if (bossHP != null)
                {
                    if (bossHP.healthPoints <= 0)
                        DemoOverCanvas.SetActive(true);
                    else
                        DemoOverCanvas.SetActive(false);
                }
            }
        }


        if (DemoOverCanvas.activeSelf == true)
            timer -= Time.deltaTime;

        if (timer <= 0)
            SceneManager.LoadScene(0);
    }
}
