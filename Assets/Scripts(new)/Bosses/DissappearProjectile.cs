using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearProjectile : MonoBehaviour
{

    public float dissappearSpeed;
    public float dissappearValue;
    public float scaleX;
    public float scaleY;


    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        
        transform.localScale = new Vector3(transform.localScale.x - 0.1f * dissappearSpeed * Time.deltaTime,
                                           transform.localScale.y - 0.1f * dissappearSpeed * Time.deltaTime, 0);

        if (scaleX <= dissappearValue)
            Destroy(gameObject);
    }
}
