using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainMenu : MonoBehaviour
{
    // Reference the in-game UI script
    private InGameUI inGameUIScript;
    // Reference the main menu UI
    public GameObject mainMenuUI;
    // Reference the how-to-play UI
    public GameObject howToPlayUI;
    // Reference how-to-play UI pages as an array
    public GameObject[] howToPlayPages;
    // Reference the credits UI
    public GameObject creditsUI;
    // Reference the in-game UI
    public GameObject inGameUI;
    // Reference the end of day UI
    public GameObject endOfDayUI;
    // Reference the end of game UI
    public GameObject endOfGameUI;

    // Start is called before the first frame update
    void Start()
    {
        // Reference the in-game UI script
        inGameUIScript = GetComponent<InGameUI>();

        // Set the main menu UI to true
        mainMenuUI.SetActive(true);
        // Set the how-to-play UI to false
        howToPlayUI.SetActive(false);
        // Set the credits UI to false
        creditsUI.SetActive(false);
        // Set the in-game UI to false
        inGameUI.SetActive(false);
        // Set the end of day UI to false
        endOfDayUI.SetActive(false);
        // Set the end of game UI to false
        endOfGameUI.SetActive(false);

        // Assert that the how-to-play UI pages array is not empty
        Debug.Assert(howToPlayPages.Length > 0, "How-to-play UI pages array is empty!");
        // Loop through the how-to-play UI pages
        for (int i = 0; i < howToPlayPages.Length; i++)
        {
            // Set the how-to-play UI pages to false
            howToPlayPages[i].SetActive(false);
        }
        // Set the first how-to-play UI page to true
        howToPlayPages[0].SetActive(true);
    }

    // Play button function
    public void Play()
    {
        // Set the main menu UI to false
        mainMenuUI.SetActive(false);
        // Set the in-game UI to true
        inGameUI.SetActive(true);

        // Set active
        inGameUIScript.isActive = true;
    }

    // How to play button function
    public void HowToPlay()
    {
        // Set the main menu UI to false
        mainMenuUI.SetActive(false);
        // Set the how-to-play UI to true
        howToPlayUI.SetActive(true);
    }

    // Toggle the main menu from how-to-play UI
    public void MainMenuReturn()
    {
        // Set the main menu UI to true
        mainMenuUI.SetActive(true);
        // Set the how-to-play UI to false
        howToPlayUI.SetActive(false);
        // Set the credits UI to false
        creditsUI.SetActive(false);
    }

    // How to play next page button function
    public void HowToPlayNextPage()
    {
        // Loop through the how-to-play UI pages
        for (int i = 0; i < howToPlayPages.Length; i++)
        {
            // If the current how-to-play UI page is active
            if (howToPlayPages[i].activeSelf)
            {
                // Set the current how-to-play UI page to false
                howToPlayPages[i].SetActive(false);
                // If the current how-to-play UI page is not the last page
                if (i < howToPlayPages.Length - 1)
                {
                    // Set the next how-to-play UI page to true
                    howToPlayPages[i + 1].SetActive(true);
                }
                // If the current how-to-play UI page is the last page
                else
                {
                    // Reactive the first how-to-play UI page
                    howToPlayPages[0].SetActive(true);
                    // Return to the main menu
                    MainMenuReturn();
                }
                // Break out of the loop
                break;
            }
        }
    }

    // Credits button function
    public void Credits()
    {
        // Set the main menu UI to false
        mainMenuUI.SetActive(false);
        // Set the credits UI to true
        creditsUI.SetActive(true);
    }

    // Quit button function
    public void Quit()
    {
        // Quit the game
        Application.Quit();
    }

    // End of day button function
    public void EndOfDay()
    {
        // Set the in-game UI to false
        inGameUI.SetActive(false);
        // Set the end of day UI to true
        endOfDayUI.SetActive(true);

        // Set inactive
        inGameUIScript.isActive = false;
    }

    // End of day return button function
    public void EndOfDayReturn()
    {
        // Set the in-game UI to true
        inGameUI.SetActive(true);
        // Set the end of day UI to false
        endOfDayUI.SetActive(false);

        // Set active
        inGameUIScript.isActive = true;
    }

    // End of game button function
    public void EndOfGame(bool win, int level)
    {
        // Set the in-game UI to false
        inGameUI.SetActive(false);
        // Set the end of game UI to true
        endOfGameUI.SetActive(true);

        // Set inactive
        inGameUIScript.isActive = false;
        // Reference the end of game script
        EndOfGame endOfGameScript = endOfGameUI.GetComponent<EndOfGame>();
        // If the player won
        if (win)
        {
            // Call the win game function
            endOfGameScript.WinGame();
        }
        // If the player lost
        else
        {
            // Call the lose game function
            endOfGameScript.LoseGame(level);
        }
    }

    // End of game return button function
    public void EndOfGameReturn()
    {
        // Restart the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
