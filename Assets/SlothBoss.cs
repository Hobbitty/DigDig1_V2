using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothBoss : MonoBehaviour
{
    [Header("Rigidbody")]
    public Rigidbody2D rbodySloths;
    [Header("Attack Gameobject")]
    public GameObject shockwave;
    public GameObject fallingRock;
    public GameObject slothMinions;
    [Header("Timers")]
    public float shockwaveTimer;
    public float fallingTimer;
    public float minionTimer;
    [Header("Frequencies")]
    public int shockwaveFrequency;
    public int fallingFrequency;
    public int minionFrequency;
    [Header("Bools")]
    public bool canAttack;
    public bool isSleeping;

    private int minionSpawnCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        rbodySloths = GetComponent<Rigidbody2D>();

        canAttack = true;

        shockwaveTimer = shockwaveFrequency;
        fallingTimer = fallingFrequency;
        minionTimer = minionFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        ShockwaveAttack();
        FallingAttack();
        MinionSpawn();
    }

    void ShockwaveAttack()
    {
        if (canAttack == true)
        {
            shockwaveTimer -= Time.deltaTime;

            if (shockwaveTimer <= 0)
            {
                print("spawning shockwave");
                Instantiate(shockwave, new Vector3(transform.position.x, transform.position.y - 5f, 0), transform.rotation);
                shockwaveTimer = shockwaveFrequency;
            }
        }
    }

    void FallingAttack()
    {
        if (canAttack == true)
        {
            fallingTimer -= Time.deltaTime;

            if (fallingTimer <= 0)
            {
                print("spawning rock");
                GameObject playerTank = GameObject.FindWithTag("Player");
                Transform playerTransform = playerTank.transform;
                Instantiate(fallingRock, new Vector3(playerTransform.position.x, 8), transform.rotation);
                Instantiate(fallingRock, new Vector3(Random.Range(-15, 5), 8), transform.rotation);
                fallingTimer = fallingFrequency;
            }
        }
    }

    void MinionSpawn()
    {
        if (canAttack == true)
        {
            minionTimer -= Time.deltaTime;

            if (minionTimer <= 0)
            {
                print("spawning minion");
                for (int f = 0; f < minionSpawnCount; f++)
                {
                    Instantiate(slothMinions, new Vector3(transform.position.x - 1, Random.Range(0, 7)), transform.rotation);
                    minionSpawnCount = Random.Range(2, 6);
                }
                minionTimer = minionFrequency;
            }
        }
    }

}
