using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Load the Game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // Close the Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
