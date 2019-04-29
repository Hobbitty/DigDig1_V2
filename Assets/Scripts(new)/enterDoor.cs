using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterDoor : MonoBehaviour
{
    public string sceneToLoad;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetDisabled(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SetDisabled(false);
    }
}
