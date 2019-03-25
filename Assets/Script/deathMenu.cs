using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathMenu : MonoBehaviour
{

    public void Continue()
    {
        Debug.Log("Continue Game...");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game...");
    }


}
