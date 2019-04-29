using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucifurTutorial : MonoBehaviour
{
    public GameObject cButton;
    public GameObject ShiftButton;
    public GameObject UpButton;

    // Start is called before the first frame update
    void Start()
    {
        SetDisabled(false, false, false);
    }

    private void SetDisabled(bool c, bool shift, bool upArrow)
    {
        cButton.SetActive(c);
        ShiftButton.SetActive(shift);
        UpButton.SetActive(upArrow);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackTutorTrigger")
            SetDisabled(true, false, false);

        if (collision.gameObject.name == "DashTutorTrigger")
            SetDisabled(false, true, false);
        if (collision.gameObject.name == "UpAttackTutorTrigger")
            SetDisabled(true, false, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackTutorTrigger")
            SetDisabled(false, false, false);
        if (collision.gameObject.name == "DashTutorTrigger")
            SetDisabled(false, false, false);
        if (collision.gameObject.name == "UpAttackTutorTrigger")
            SetDisabled(false, false, false);
    }

}
