﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Jump")]
    public float jumpHeight;
    public float currentJumpTime;
    public float maxJumpTime;
    private bool isJumping;
    [Space]

    [Header("Movement")]
    public float moveSpeed;
    private float moveInput;
    [Space]
    [Header("Other")]
    private Rigidbody2D rBody;
    public IsGrounded iG;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(moveInput * moveSpeed, rBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && iG.isGrounded == true)
        {
            isJumping = true;
            currentJumpTime = maxJumpTime;
            rBody.velocity = new Vector2(rBody.velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (currentJumpTime > 0)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpHeight);
                currentJumpTime -= Time.deltaTime;
            }
            else
                isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;


    }
}
