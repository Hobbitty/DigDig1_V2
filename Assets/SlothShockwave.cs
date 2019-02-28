using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothShockwave : MonoBehaviour
{
    public float travelSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-travelSpeed * Time.deltaTime, 0));
    }
}
