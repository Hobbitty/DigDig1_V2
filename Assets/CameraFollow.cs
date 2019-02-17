using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTank;

    public bool bounds = true;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;


    private void FixedUpdate()
    {
        transform.position = new Vector3(playerTank.position.x, playerTank.position.y, -1);

        if (bounds == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x)
               , Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y), -1);
        }

    }

}
