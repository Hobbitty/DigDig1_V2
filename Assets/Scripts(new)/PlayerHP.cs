﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float hP;
    public float numberOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float maxHearts;
    public string deathScene;

    void Update()
    {
        HeartNumber();
        TakingDamage healthLoss = GetComponent<TakingDamage>();
        maxHearts = healthLoss.maxHP;
        numberOfHearts = healthLoss.maxHP;
        hP = healthLoss.currentHP;
        Dead();
    }
    
    void HeartNumber()
    {
        if (hP > numberOfHearts)
        {
            hP = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    void Dead()
    {
        if (hP <= 0)
        {
    
        }
    }
}