using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraYPosition;
    public Transform playerTank;
    public float cameraYValue;
    

    private void FixedUpdate()
    {
        cameraYPosition = playerTank.position.y + cameraYValue;
        transform.position = new Vector3(playerTank.position.x, cameraYPosition, -1);
        
    }

}
