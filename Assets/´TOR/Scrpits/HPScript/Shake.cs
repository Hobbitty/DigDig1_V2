using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeSpeed;
    public float shakeAmount;
    private float lowHealth;
    private float oneHP = 1f;
    public PlayerHP playerHP;

    // Update is called once per frame
    void Update()
    {
        Hurt();
    }

    Vector2 startingPos;
    void Awake()
    {
        startingPos.x = transform.localPosition.x;
        startingPos.y = transform.localPosition.y;
    }
    void Hurt()
    {

        float lowHealth = playerHP.numberOfHearts / 2;

        if (playerHP.hP <= lowHealth)
        {
            shakeSpeed = 10;
            shakeAmount = 1;

            Vector2 pos = transform.localPosition;
            pos.x = startingPos.x + (Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);
            pos.y = startingPos.y + (Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);
            transform.localPosition = pos;
        }

        if (playerHP.hP <= oneHP)
        {
            shakeSpeed = shakeSpeed * 5;
            shakeAmount = 1;

            Vector2 pos = transform.localPosition;
            pos.x = startingPos.x + (Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);
            pos.y = startingPos.y + (Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);
            transform.localPosition = pos;
        }
    }
}