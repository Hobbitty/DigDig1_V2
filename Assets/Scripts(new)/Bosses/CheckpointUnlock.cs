using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUnlock : MonoBehaviour
{
    public bool inRange = false;
    public GameObject keyPress;
    public Sprite unlockedSprite;

    private bool unlocked;
    private SpriteRenderer rend;
    private CheckpointManagerScript cpMS;
    private Sprite lockedSprite;
    private buttonScript bScript;
    private GameObject newObject;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        cpMS = GameObject.FindWithTag("CheckpointManager").GetComponent<CheckpointManagerScript>();
        lockedSprite = rend.sprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
            if (unlocked == false)
            {
                GameObject newObject = Instantiate(keyPress, transform);
                bScript = newObject.GetComponent<buttonScript>();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
            Destroy(GameObject.FindWithTag("KeyPress"));
        }
    }

    private void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Invoke("Unlock", 1.5f);

            bScript.rend.color = new Color(0.5f, 0.5f, 0.5f);
            bScript.transform.localScale = bScript.pressSize;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            CancelInvoke();
            if (bScript != null)
            {
                bScript.rend.color = new Color(1, 1, 1);
                bScript.transform.localScale = bScript.realSize;
            }
        }

        if (transform.position == cpMS.lastCheckPos)
        {
            rend.sprite = unlockedSprite;
            unlocked = true;
        }
        else
        {
            rend.sprite = lockedSprite;
            unlocked = false;
        }

    }
    void Unlock()
    {
        cpMS.lastCheckPos = transform.position;
        Destroy(GameObject.FindWithTag("KeyPress"));
    }
}