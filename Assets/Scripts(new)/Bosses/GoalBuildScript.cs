using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBuildScript : MonoBehaviour
{
    

    private int buildDirection;
    private Transform goalBuildPos;

    private void Start()
    {
        goalBuildPos = GameObject.Find("GoalBuildPos").GetComponent<Transform>();
        buildDirection = Random.Range(1, 5);
        BuildPosSet();

    }
    void BuildPosSet()
    {
        if (buildDirection == 1)
        {
            goalBuildPos.position = new Vector2(1, 0);
        }
        else if (buildDirection == 2)
        {
            goalBuildPos.position = new Vector2(-1, 0);
        }
        else if (buildDirection == 3)
        {
            goalBuildPos.position = new Vector2(0, 1);
        }
        else if (buildDirection == 4)
        {
            goalBuildPos.position = new Vector2(0, -1);
        }
    }
    void Build()
    {

    }
}
