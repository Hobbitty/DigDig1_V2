using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathSceneManager : MonoBehaviour
{
    public int menuScene;
    public int continueScene;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("DeathManager");
        UponDeath deathManager = player.GetComponent<UponDeath>();

        continueScene = deathManager.LevelPlayerDiedOnIndex;

        menuScene = SceneManager.GetSceneByBuildIndex(0).buildIndex;
    }

    public void LoadContinue()
    {
        SceneManager.LoadScene(continueScene);
    }
    
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

}
