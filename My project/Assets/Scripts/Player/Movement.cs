using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    // Gamemanager
    public GameManager gm;

    // Obstacle Spawner
    public ObstacleSpawner obstacleSpawner;

    // Player
    private Rigidbody2D rb2d;
    [SerializeField]
    private float jumpForce;

    // UI
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody2D, Reference to GameManager script and the ObstacleSpawner
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        obstacleSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set Static and disable sprite renderer if run has not started
        if(obstacleSpawner.hasStarted == false)
        {
            rb2d.bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            // Set to Dynamic and enable sprite renderer 
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        // Score Update
        ScoreText.text = "SCORE: " + gm.score.ToString();

        // Check run has started
        if (obstacleSpawner.hasStarted == true)
        {
            // Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    // Jump
    private void Jump()
    {
        // Move rigidbody UP
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }

    // Die
    private void GameOver()
    {
        // DESTROY OBJECT and call the GameOver function from the Gamemanager
        Destroy(gameObject);
        gm.GameOver();
    }

    // +1
    private void Score()
    {
        // Increase the score by 1 via the Gamemanager script
        gm.score++;
    }

    // Trigger Collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Die
        if (other.gameObject.CompareTag("Boundries"))
        {
            GameOver();
        }

        // Score
        if (other.gameObject.CompareTag("Score"))
        {
            Score();
        }
    }
}
