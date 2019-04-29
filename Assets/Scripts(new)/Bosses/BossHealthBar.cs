using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    EnemyHealth enemyHP;
    public int enemyHpValue;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BHB();
    }

    void BHB()
    {
        enemyHpValue = enemyHP.healthPoints;

    }
}
