using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathSceneManager : MonoBehaviour
{
    public string menuScene;
    public string continueScene;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        UponDeath deathManager = player.GetComponent<UponDeath>();

        continueScene = deathManager.LevelPlayerDiedOn;

    }

}
