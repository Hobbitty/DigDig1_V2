using System.Collections;
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
    [Header("Dash")]
    public float dashSpeed;
    private bool isDashing;
    private bool canDash;
    private int dashCounter;
    
    [Space]
    [Header("Other")]
    public float gravity;
    private Rigidbody2D rBody;
    public IsGrounded iG;

    [Space]
    [Header("Animation")]
    public Animator playerAnimator;
    public float horizontalMovement;

    private void Start()
    {
        isJumping = false;
        dashCounter = 0;
        rBody = GetComponent<Rigidbody2D>();
        gravity = rBody.gravityScale;
    }

    private void FixedUpdate()
    {

        if (enemyAttack.IsKnockbacked || PlayerKnockback.IsKnockbacked == false)
        {
            Jump();
            if (isDashing == false)
            {
                moveInput = Input.GetAxis("Horizontal");
                rBody.velocity = new Vector2(moveInput * moveSpeed, rBody.velocity.y);

                if (moveInput < 0)
                    transform.eulerAngles = new Vector2(0, 180);

                if (moveInput > 0)
                    transform.eulerAngles = new Vector2(0, 0);
            }

            if(rBody.velocity.y == 0)
            {
              playerAnimator.SetBool("isJumping", false);
            }
            if (rBody.velocity.y > 0)
            {
                playerAnimator.SetBool("isJumping", true);
            }

            horizontalMovement = Input.GetAxis("Horizontal");
            playerAnimator.SetFloat("Horizontal", (Mathf.Abs(horizontalMovement)));
        
            

            if (dashCounter == 1)
                canDash = false;

            if (iG.isGrounded == true)
            {
                canDash = true;
                dashCounter = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
            {
                if (iG.isGrounded == true)
                {
                    isDashing = true;
                    rBody.gravityScale = 0;
                    Invoke("IsNotDashing", 0.5f);
                    rBody.velocity = transform.right * dashSpeed;
                }
                else
                {
                    dashCounter += 1;
                    isDashing = true;
                    rBody.gravityScale = 0;
                    Invoke("IsNotDashing", 0.5f);
                    rBody.velocity = transform.right * dashSpeed;
                }
            }
        }



    }

    void IsNotDashing()
    {
        if (enemyAttack.IsKnockbacked == false)
        {
            isDashing = false;
            rBody.gravityScale = gravity;
        }

    }
    void Jump()
    {

        if (enemyAttack.IsKnockbacked || PlayerKnockback.IsKnockbacked == false)
        {
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
            {
                isJumping = false;
            }
        }


    }

}
