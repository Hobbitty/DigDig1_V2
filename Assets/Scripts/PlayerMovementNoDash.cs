using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNoDash : MonoBehaviour
{
    [Header("Jump")]
    public float noDashjumpHeight;
    public float noDashcurrentJumpTime;
    public float noDashmaxJumpTime;
    private bool noDashisJumping;
    [Space]

    [Header("Movement")]
    public float noDashmoveSpeed;
    private float noDashmoveInput;
    [Space]
    [Header("Other")]
    private Rigidbody2D noDashRbody;
    public IsGrounded noDashIsGrounded;
    [Header("Turn Around")]
    public bool noDashfacingLeft;
    public float noDashlookLeftScale;

    private void Start()
    {
        noDashRbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        noDashmoveInput = Input.GetAxisRaw("Horizontal");
        noDashRbody.velocity = new Vector2(noDashmoveInput * noDashmoveSpeed, noDashRbody.velocity.y);

        if (noDashmoveInput < 0)
        {
            noDashfacingLeft = true;
            transform.localScale = new Vector3(-noDashlookLeftScale, 0.3f);
        }
        if(noDashmoveInput > 0)
        {
            noDashfacingLeft = false;
            transform.localScale = new Vector3(noDashlookLeftScale, 0.3f);
        }


        if (Input.GetKeyDown(KeyCode.Space) && noDashIsGrounded.isGrounded == true)
        {
            noDashisJumping = true;
            noDashcurrentJumpTime = noDashmaxJumpTime;
            noDashRbody.velocity = new Vector2(noDashRbody.velocity.x, noDashjumpHeight);
        }
        if (Input.GetKey(KeyCode.Space) && noDashisJumping == true)
        {
            if (noDashcurrentJumpTime > 0)
            {
                noDashRbody.velocity = new Vector2(noDashRbody.velocity.x, noDashjumpHeight);
                noDashcurrentJumpTime -= Time.deltaTime;
            }
            else
                noDashisJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
            noDashisJumping = false;
    }
}
