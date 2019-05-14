using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player360AttackScript : MonoBehaviour
{
    public GameObject hurtBox;

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 diff = ray.GetPoint(0) - transform.position;
            print(diff);

            GameObject newObject = Instantiate(hurtBox);
            newObject.transform.position = new Vector3(newObject.transform.position.x,newObject.transform.position.y,0);
            newObject.transform.LookAt(ray.GetPoint(0));
        }
    }
}
