using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerFeedbackScript : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Touch");
        }
    }
}
