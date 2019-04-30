using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
    public string sceneToLoad;

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game...");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }


}
