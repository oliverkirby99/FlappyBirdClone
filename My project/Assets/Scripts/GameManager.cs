using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Camera
    private Camera cam;
    // Score
    public int score;
    // High Score
    private int highScore;
    public TextMeshProUGUI highScoreText;
    // Game Over
    public GameObject GameOverText;
    private bool gameIsOver = false;

    

    void Start()
    {
        // Set Camera and change background colour to Blue
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam.backgroundColor = Color.blue;

        // Set Highscore
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        // If dead
        if(gameIsOver)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // Restart the level.
                SceneManager.LoadScene(1);
                // Reset the timeScale
                Time.timeScale = 1;
            }
        }

        // Press Backspace to reset Highscore
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }

        // Quit
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }
    }

    // Change Background Colour
    public void BGColour()
    {
        // If the background is Blue, make it Red
        if(cam.backgroundColor == Color.blue)
        {
            cam.backgroundColor = Color.red;
        }
        // If the background is Red, make it Blue
        else
        {
            cam.backgroundColor = Color.blue;
        }
    }

    public void GameOver()
    {
        // Chang Background Colour
        BGColour();
        // Slow Motion Effect
        Time.timeScale = 0.75f;
        // Display the GameOver text
        GameOverText.SetActive(true);
        gameIsOver = true;

        // Update Highscore
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }
}