using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    // Reference the day text
    public Image dayText;
    // Reference the day text sprites array
    public Sprite[] dayTextSprites;
    // Reference the day fill
    public Image dayFill;
    // Reference the pheromone fill
    public Image pheromoneFill;
    // Reference the food fill
    public Image foodFill;
    // Reference the water fill
    public Image waterFill;
    // Reference the honeydew fill
    public Image honeydewFill;
    // Reference the building material fill
    public Image buildingMaterialFill;

    // Track the nest level
    public int level = 1;
    // Track the current day
    public int currentDay = 0;
    // Track the day timer
    public float dayTimer = 1.0f;
    // Track the pheromone
    public float pheromone = 1.0f;
    // Track the food
    public float food = 0.5f;
    // Track the water
    public float water = 0.5f;
    // Track the honeydew
    public int honeydew = 3;
    // Track the building materials
    public float buildingMaterials = 0.0f;

    public void Start()
    {
        // Set the day text
        SetDayText(currentDay);
        // Set the day fill
        SetDayFill(dayTimer);
        // Set the pheromone fill
        SetPheromoneFill(pheromone);
        // Set the food fill
        SetFoodFill(food);
        // Set the water fill
        SetWaterFill(water);
        // Set the honeydew fill
        SetHoneydewFill(honeydew);
        // Set the building material fill
        SetBuildingMaterialFill(buildingMaterials);
    }

    // Set the day text
    public void SetDayText(int day)
    {
        // Assert that the day text sprites array is not empty
        Debug.Assert(dayTextSprites.Length > 0, "Day text sprites array is empty!");
        // Assert that the day text sprites array has enough sprites
        Debug.Assert(dayTextSprites.Length >= day, "Day text sprites array does not have enough sprites!");
        // Set the day text sprite
        dayText.sprite = dayTextSprites[day];
    }

    // Set the day fill
    public void SetDayFill(float fill)
    {
        // Assert that the fill is between 0 and 1
        Debug.Assert(fill >= 0 && fill <= 1, "Fill is not between 0 and 1!");
        // Set the day fill
        dayFill.fillAmount = fill;
    }

    // Set the pheromone fill
    public void SetPheromoneFill(float fill)
    {
        // Assert that the fill is between 0 and 1
        Debug.Assert(fill >= 0 && fill <= 1, "Fill is not between 0 and 1!");
        // Set the pheromone fill
        pheromoneFill.fillAmount = fill;
    }

    // Set the food fill
    public void SetFoodFill(float fill)
    {
        // Assert that the fill is between 0 and 1
        Debug.Assert(fill >= 0 && fill <= 1, "Fill is not between 0 and 1!");
        // Set the food fill
        foodFill.fillAmount = fill;
    }

    // Set the water fill
    public void SetWaterFill(float fill)
    {
        // Assert that the fill is between 0 and 1
        Debug.Assert(fill >= 0 && fill <= 1, "Fill is not between 0 and 1!");
        // Set the water fill
        waterFill.fillAmount = fill;
    }

    // Set the honeydew fill
    public void SetHoneydewFill(int fill)
    {
        // Assert that the fill is between 0 and 5
        Debug.Assert(fill >= 0 && fill <= 5, "Fill is not between 0 and 5!");
        // Set the day fill
        honeydewFill.fillAmount = 0.2f * fill;
    }

    // Set the building material fill
    public void SetBuildingMaterialFill(float fill)
    {
        // Assert that the fill is between 0 and 1
        Debug.Assert(fill >= 0 && fill <= 1, "Fill is not between 0 and 1!");
        // Set the building material fill
        buildingMaterialFill.fillAmount = fill;
    }
}
