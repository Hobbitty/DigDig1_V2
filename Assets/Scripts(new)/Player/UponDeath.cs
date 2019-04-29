using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UponDeath : MonoBehaviour
{
    public int LevelPlayerDiedOnIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        TakingDamage getScene = player.GetComponent<TakingDamage>();
        
        LevelPlayerDiedOnIndex = getScene.lvlPlayerDiedOn;
    }

}
