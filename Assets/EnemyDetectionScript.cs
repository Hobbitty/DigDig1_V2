using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour
{
    public bool inRange;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inRange = true; 
    }
}
