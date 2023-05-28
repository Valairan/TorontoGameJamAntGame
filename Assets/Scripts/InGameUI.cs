using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public bool isActive = false;

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
    public int maxDay = 9;
    // Track the day timer
    public float initialDayTimer = 60.0f;
    public float currentDayTimer = 60.0f;
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
        SetDayFill(currentDayTimer);
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

    public void Update()
    {
        if (!isActive) return;
        TickInGameUI(Time.deltaTime);
    }

    public void SetActive()
    {
        isActive = true;
    }

    public void SetInactive()
    {
        isActive = false;
    }

    public void TickInGameUI(float delta)
    {
        TickDayTimer(delta);
        TickFood(delta);
        TickWater(delta);
    }

    public void SetNextDay()
    {
        currentDay++;
        if (currentDay > maxDay) {
            currentDay = maxDay;
        }
        SetDayText(currentDay);
    }

    public void TickDayTimer(float delta)
    {
        currentDayTimer -= delta;
        if (currentDayTimer < 0) {
            currentDayTimer = 0;
        }
        if (currentDayTimer == 0) {
            SetNextDay();
            currentDayTimer = initialDayTimer;
        }
        SetDayFill(currentDayTimer);
    }

    public void TickPheromone()
    {
        pheromone -= 0.01f;
        if (pheromone < 0) {
            pheromone = 0;
        }
        SetPheromoneFill(pheromone);
    }

    public void TickFood(float delta)
    {
        food -= 0.02f * delta;
        if (food < 0) {
            food = 0;
        }
        SetFoodFill(food);
    }

    public void TickWater(float delta)
    {
        water -= 0.01f * delta;
        if (water < 0) {
            water = 0;
        }
        SetWaterFill(water);
    }

    public void LoseHoneydew()
    {
        honeydew--;
        if (honeydew < 0) {
            honeydew = 0;
        }
        SetHoneydewFill(honeydew);
    }

    public void GainHoneydew()
    {
        honeydew++;
        if (honeydew > 5) {
            honeydew = 5;
        }
        SetHoneydewFill(honeydew);
    }

    public void GainBuildingMaterials()
    {
        buildingMaterials += 0.2f;
        if (buildingMaterials >= 1.0f) {
            buildingMaterials -= 1.0f;
            level++;
        }
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
        Debug.Assert(fill >= 0 && fill <= initialDayTimer, "Fill is not between 0 and 60!");
        // Set the day fill
        dayFill.fillAmount = fill / initialDayTimer;
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
