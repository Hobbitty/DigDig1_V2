using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButtonLoadScene : MonoBehaviour
{
    public string sceneToLoad;
   
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
