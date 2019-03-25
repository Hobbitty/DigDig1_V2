using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTank;

    public bool bounds = true;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    private Vector2 CameraYPos;
    public float CameraYMinPos;


    private void FixedUpdate()
    {
        CameraYPos.y = playerTank.position. y + CameraYMinPos;

        transform.position = new Vector3(playerTank.position.x, CameraYPos.y, -1);

        if (bounds == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x)
               , Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y), -1);
        }
    }
}
