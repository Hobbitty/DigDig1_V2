using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingAnimation : MonoBehaviour
{

    public Animator playerAnimator;
    public float horizontalMovement;

    void Start()
    {
        
    }

    void Update()
    {
        if(lvl1Transition.frozen == true)
        {
            horizontalMovement = 0;
        }
        horizontalMovement = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Horizontal", (Mathf.Abs(horizontalMovement)));
    }
}
