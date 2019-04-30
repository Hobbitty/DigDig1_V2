using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterDoor : MonoBehaviour
{
    public string sceneToLoad;
    public float timer;
    public AudioSource openDoor;
    public SpriteRenderer door;
    public Sprite doorOpen;
    public bool doorIsOpen;

    [Header("eButton")]
    public GameObject eButton;

    private void Start()
    {
        SetDisabled(false);
    }

    private void SetDisabled(bool b)
    {
        eButton.SetActive(b);
    }

    private void Update()
    {
        if (timer >= 2)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        if (doorIsOpen == true)
        {
            timer = timer + 1 * Time.deltaTime;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //SetDisabled(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                door.sprite = doorOpen;
                openDoor.Play();
                doorIsOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
        //SetDisabled(false);
    }
}
