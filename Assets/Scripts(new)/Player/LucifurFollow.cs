using UnityEngine;

public class LucifurFollow : MonoBehaviour
{
    public float moveSpeed;
    public float catJump;
    public Vector2 playerTank;
    public IsGrounded groundCheck;

    private Rigidbody2D rbodyCat;

    // Start is called before the first frame update
    void Start()
    {
        rbodyCat = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;

        PlayerMovement playerFollow = player.GetComponent<PlayerMovement>();
        moveSpeed = playerFollow.moveSpeed - (playerFollow.moveSpeed / 4);
        catJump = playerFollow.jumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        ChangeDirection();
        IfTooFar();

        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;

        if (transform.position.y < playerTrans.position.y - 0.5)
            JumpingAfterPlayer();
    }

    void ChangeDirection()
    {

        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;
        playerTank = new Vector2(playerTrans.position.x, playerTrans.position.y);

        if (transform.position.x > playerTrans.position.x)
            transform.localScale = new Vector3(
                -1,
                transform.localScale.y);
        else
            transform.localScale = new Vector3(
             1,
             transform.localScale.y);
    }

    void FollowPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;

        PlayerMovement playerTurn = GetComponent<PlayerMovement>();
        float step = moveSpeed * Time.deltaTime; // calculate distance to move

        Vector2 vel = rbodyCat.velocity;
        if (transform.position.x - playerTrans.position.x > 1)
            vel.x = -moveSpeed;
        else if (transform.position.x - playerTrans.position.x < -1)
            vel.x = moveSpeed;
        else
            vel.x = 0;
        rbodyCat.velocity = vel;
    }

    void JumpingAfterPlayer()
    {
        rbodyCat.velocity = new Vector2(rbodyCat.velocity.x, catJump);
    }

    void IfTooFar()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTrans = player.transform;

        if (transform.position.x < playerTrans.position.x - 20 ||
            transform.position.x > playerTrans.position.x + 20 ||
            transform.position.y < playerTrans.position.y - 20 ||
            transform.position.y > playerTrans.position.y + 20)
            transform.position = new Vector2(playerTrans.position.x - 1, playerTrans.position.y);
    }
}
