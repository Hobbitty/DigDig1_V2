using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTank;

    public bool bounds = true;

    public static bool secondPos;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    private Vector2 CameraYPos;
    public float CameraYMinPos;
    public Vector3 minCamPos2;
    public Vector3 maxCamPos2;


    private void Start()
    {
        FindPlayer();
        
    }

    private void FixedUpdate()
    {
        CameraYPos.y = playerTank.position.y + CameraYMinPos;

        transform.position = new Vector3(playerTank.position.x, CameraYPos.y, -1);

        if (bounds == true)
        {

            if (secondPos == false)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x)
                          , Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y), -1);
            }

            if(secondPos == true)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos2.x, maxCamPos2.x)
                          , Mathf.Clamp(transform.position.y, minCamPos2.y, maxCamPos2.y), -1);
            }

        }
    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;

        playerTank = playerTrans;
    }
}
