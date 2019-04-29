using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosScript : MonoBehaviour
{
    private CheckpointManagerScript cpMS;

    private void Start()
    {
        cpMS = GameObject.FindWithTag("CheckpointManager").GetComponent<CheckpointManagerScript>();
        transform.position = cpMS.lastCheckPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}