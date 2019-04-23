using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UponDeath : MonoBehaviour
{
    public string LevelPlayerDiedOn;

    // Start is called before the first frame update
    void Start()
    {
        LevelPlayerDiedOn = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
