using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGame : MonoBehaviour
{
    // Reference the win UI
    public GameObject winUI;
    // Reference the lose UI
    public GameObject loseUI;
    // Reference the day text
    public Image dayText;
    // Reference the day text sprites array
    public Sprite[] dayTextSprites;

    // Win game function
    public void WinGame()
    {
        // Set the win UI to true
        winUI.SetActive(true);
        // Set the lose UI to false
        loseUI.SetActive(false);
    }

    // Lose game function
    public void LoseGame(int level)
    {
        // Set the win UI to false
        winUI.SetActive(false);
        // Set the lose UI to true
        loseUI.SetActive(true);

        // Assert that the day text sprites array is not empty
        Debug.Assert(dayTextSprites.Length > 0, "Day text sprites array is empty!");
        // Assert that the day text sprites array has enough sprites
        Debug.Assert(dayTextSprites.Length >= level - 1, "Day text sprites array does not have enough sprites!");        
        // Set the day text to the lose sprite
        dayText.sprite = dayTextSprites[level - 1];
    }
}
