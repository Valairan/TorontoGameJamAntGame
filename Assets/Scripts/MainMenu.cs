using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainMenu : MonoBehaviour
{
    // Reference the main menu UI
    public GameObject mainMenuUI;
    // Reference the how-to-play UI
    public GameObject howToPlayUI;
    // Reference how-to-play UI pages as an array
    public GameObject[] howToPlayPages;

    // Start is called before the first frame update
    void Start()
    {
        // Set the main menu UI to true
        mainMenuUI.SetActive(true);
        // Set the how-to-play UI to false
        howToPlayUI.SetActive(false);

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
}
