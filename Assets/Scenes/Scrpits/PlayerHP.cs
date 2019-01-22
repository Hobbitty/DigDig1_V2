using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    
    public float playerHP = 100;
    public Scene DeatheScene;

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    void Dead()
    {
        if(playerHP == 0)
        {
            //Load "DeathScene"
        }
    }

    void LowHP()
    {
        if(playerHP <= 30)
        {
            //Något händer som indikerar att man är skadad, Blod på karaktär, pultserande rött runt skrämen .....
        }
    }
}
