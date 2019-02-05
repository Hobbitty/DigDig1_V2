using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyScript : MonoBehaviour
{
    [Header("Scripts")]
    public ShooterOnGroundScript shooterOnGroundScript;
    public InRangeCheck inRangeCheck;

    [Header("Player")]
    public Transform Player;

    [Header("Enemy")]
    public Rigidbody2D rBody;
    public float moveSpeed;

    [Header("Other")]
    public bool shooting = false;
    public float chargeTime;



    private void Update()
    {
        if (shooterOnGroundScript.touches > 0 && shooting == false)
        {
            Move();
        }
        if (inRangeCheck.inRange == true)
        {
            rBody.velocity = new Vector2(0, 0);
        }

    }
    void Move()
    {
        rBody.velocity = (-transform.right * moveSpeed) * Time.deltaTime;

        if (Player.position.x > transform.position.x)   
        {
            transform.localScale = new Vector2(-1, 1);
            transform.eulerAngles = new Vector2 (0, 180);
        }

        else
        {
            transform.localScale = new Vector2(1, 1);
            transform.eulerAngles = new Vector2(0, 0);
        }


    }
}
