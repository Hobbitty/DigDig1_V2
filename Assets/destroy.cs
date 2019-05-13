using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public int timer;
    public static bool playerPickedUpAmmo;
    public AudioSource reload;
    private Rigidbody2D rBody;
    public bool bossFight;
    public float bossTImer;
    public int fall;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.bodyType = RigidbodyType2D.Static;
        rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
       if(timer >= 1)
        {
            Destroy(gameObject);
        }

        if (bossFight == true)
        {
            bossTImer = bossTImer + 1 * Time.deltaTime;

            if(bossTImer >= 30)
            {
                fall = Random.Range(1, 1000);
            }

            if(fall == 50)
            {
                fall = 50;
                rBody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timer = timer + 1;
            playerPickedUpAmmo = true;
            reload.Play();
        }
    }
}
