using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundScript : MonoBehaviour

{
    [Header("Sounds")]
    public AudioClip footStepSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    [Space]
    [Header("Other")]
    public float interval;

    private AudioSource source;

    public bool canLand;
    private bool canJump = true;
    private bool step = true;
    private IsGrounded ig;

    private void Start()
    {
        ig = gameObject.GetComponentInChildren<IsGrounded>();
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {

        FootStep();
        Jump();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            source.PlayOneShot(jumpSound);
            canJump = false;
            canLand = true;
        }
        if (ig.isGrounded == true)
        {
            canJump = true;

            if (canLand == true)
            {
                source.PlayOneShot(landSound);
                canLand = false;
            }

        }
    }
    void FootStep()
    {
        if (Input.GetAxis("Horizontal") != 0 && step == true && ig.isGrounded == true)
        {
            source.PlayOneShot(footStepSound);
            step = false;
            Invoke("StepTrue", interval);
        }
    }
    void StepTrue()
    {
        step = true;
    }
}

