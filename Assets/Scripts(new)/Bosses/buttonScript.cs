using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public Vector3 realSize;
    public Vector3 pressSize;
    public SpriteRenderer rend;
    private CheckpointUnlock cU;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        realSize = transform.localScale;
        cU = gameObject.GetComponentInParent<CheckpointUnlock>();
    }

    private void Update()
    {
        if(cU.inRange == false)
        {
            Destroy(gameObject);
        }
        //if (cU.inRange == true && Input.GetKeyDown(KeyCode.E))
        //{
        //    transform.localScale = pressSize;
        //    rend.color = new Color(0.5f, 0.5f, 0.5f);
        //}
        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    rend.color = new Color(1, 1, 1);
        //    transform.localScale = realSize;
        //}

    }
}
