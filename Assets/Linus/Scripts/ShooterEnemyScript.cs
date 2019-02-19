using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyScript : MonoBehaviour
{
    [Header("Scripts")]
    public ShooterOnGroundScript shooterOnGroundScript;
    public InRangeCheck inRangeCheck;

    [Header("Enemy")]
    public Rigidbody2D rBody;
    public float moveSpeed;

    [Header("Other")]
    public bool shooting = false;
    public float chargeTime;
    public GameObject parent;

    private Transform player;
    private GameObject playerObject;

    private void Start()

    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Transform>();

        Instantiate(parent);

    }  


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
        


<<<<<<< HEAD:Assets/Linus/Scripts/ShooterEnemyScript.cs
        if (player.position.x > transform.position.x)   
=======
        if (player.position.x > transform.position.x)
>>>>>>> 85e50578f0b6bf95eaebc8b07440310b27de9071:Assets/Scripts/ShooterEnemyScript.cs

        {
            transform.localScale = new Vector2(-1, 1);
            rBody.velocity = (transform.right * moveSpeed) * Time.deltaTime;
        }

        else
        {
            transform.localScale = new Vector2(1, 1);
            rBody.velocity = (-transform.right * moveSpeed) * Time.deltaTime;
        }


    }
}
