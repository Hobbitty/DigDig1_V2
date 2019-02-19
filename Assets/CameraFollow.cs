using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTank;

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerTank.position.x, playerTank.position.y, -1);
    }

}
