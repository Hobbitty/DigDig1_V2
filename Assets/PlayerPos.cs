using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private CheckpointManagerScript cms;

    private void Start()
    {
        cms = GameObject.FindWithTag("CheckpointManager").GetComponent<CheckpointManagerScript>();

        transform.position = cms.lastCheckPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
    }
}
