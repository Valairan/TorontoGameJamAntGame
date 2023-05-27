using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Print to console
        Debug.Log("Play Game");
    }

    public void QuitGame()
    {
        // Print to console
        Debug.Log("Quit Game");
        // Quit the game
        Application.Quit();
    }
}
