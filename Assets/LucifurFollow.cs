using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucifurFollow : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 playerTank;

    private Rigidbody2D rbodyCat;
    // Start is called before the first frame update
    void Start()
    {
        rbodyCat = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;

        PlayerMovement playerFollow = player.GetComponent<PlayerMovement>();
        moveSpeed = playerFollow.moveSpeed - (playerFollow.moveSpeed / 4);

    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;
        playerTank = new Vector2(playerTrans.position.x, playerTrans.position.y);

        if(transform.position.x > playerTrans.position.x)
            transform.localScale = new Vector3(
                -1,
                transform.localScale.y);
        else
               transform.localScale = new Vector3(
                1,
                transform.localScale.y);
            

        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position,
                                                    new Vector3(playerTrans.position.x - 1,
                                                    playerTrans.position.y - 0.5136f),
                                                    step);
    }
}
