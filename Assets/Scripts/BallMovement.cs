using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initalSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text AIScore;

    private int hitCounter;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartBall();
    }
    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initalSpeed + (speedIncrease * hitCounter));
    }
    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PaddleBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;
        Vector2 Direction;
        float xDirection, yDirection, paddleHeight;
        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        paddleHeight = myObject.GetComponent<Collider2D>().bounds.size.y;
        yDirection = (ballPos.y - playerPos.y) / paddleHeight;
        if (yDirection == 0)
        {
            if (Random.Range(0,2) == 0)
            {
                yDirection = 0.25f;
            } 
            else
            {
                yDirection = -0.25f;
            }
            
        }
        Direction = new Vector2(xDirection, yDirection);
        rb.velocity = Direction * (initalSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PaddleBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        else
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }




    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initalSpeed + (speedIncrease * hitCounter));

    }
}
