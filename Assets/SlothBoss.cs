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
    public GameObject fireball;
    public ParticleSystem sleepingParticlesSloth;
    [Header("Timers")]
    public float shockwaveTimer;
    public float fallingTimer;
    public float minionTimer;
    public float fireballTimer;
    public float sleepingTimer;
    [Header("Frequencies")]
    public int shockwaveFrequency;
    public int fallingFrequency;
    public int minionFrequency;
    public int fireballFrequency;
    public int sleepingFrequency;
    [Header("Bools")]
    public bool canAttack;
    public bool isSleeping;

    private int minionSpawnCount = 3;
    private int healthTreshold;


    // Start is called before the first frame update
    void Start()
    {
        rbodySloths = GetComponent<Rigidbody2D>();

        canAttack = true;

        shockwaveTimer = shockwaveFrequency;
        fallingTimer = fallingFrequency;
        minionTimer = minionFrequency;
        sleepingTimer = sleepingFrequency;
        fireballTimer = fireballFrequency;
        
        EnemyHealth slothHealth = GetComponent<EnemyHealth>();
        healthTreshold = slothHealth.healthPoints / 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        ShockwaveAttack();
        FallingAttack();
        MinionSpawn();
        FireballSpawn();
        SleepingWindows();
        
        EnemyHealth slothHealth = GetComponent<EnemyHealth>();
        if (slothHealth.healthPoints < healthTreshold) 
        {
            shockwaveFrequency /= 3;
            fallingFrequency /= 2;
            minionFrequency /= 2;
            sleepingFrequency /= 4;

            healthTreshold = 0;
        }
    }

    void ShockwaveAttack()
    {
        if (canAttack == true)
        {
            shockwaveTimer -= Time.deltaTime;

            if (shockwaveTimer <= 0)
            {
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
                for (int f = 0; f < minionSpawnCount; f++)
                {
                    Instantiate(slothMinions, new Vector3(transform.position.x - 1, Random.Range(0, 7)), transform.rotation);
                    minionSpawnCount = Random.Range(2, 6);
                }
                minionTimer = minionFrequency;
            }
        }
    }

    void FireballSpawn()
    {
        if(canAttack == true)
        {
            fireballTimer -= Time.deltaTime;

            if(fireballTimer <= 0)
            {
                Instantiate(fireball, new Vector2(transform.position.x - 6, transform.position.y),
                    transform.rotation);
                fireballTimer = fireballFrequency;
            }
        }
    }

    void SleepingWindows()
    {
        sleepingTimer -= Time.deltaTime;

        if (sleepingTimer <= 0)
        {
            if (isSleeping == true)
            {
                isSleeping = false;
                sleepingTimer = sleepingFrequency;
            }
            else
            {
                isSleeping = true;
                sleepingTimer = sleepingFrequency / 4;
                Instantiate(sleepingParticlesSloth, transform.position, transform.rotation);
            }

            if (canAttack == true)
                canAttack = false;
            else
                canAttack = true;

        }

    }
}
